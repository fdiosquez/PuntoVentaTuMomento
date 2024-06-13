<?php 

  header('Access-Control-Allow-Origin: *');
  header('Access-Control-Allow-Methods: POST, GET, DELETE, PUT, PATCH, OPTIONS');
  header('Content-Type: text/html; charset=utf-8');			

  require_once('data/class.database.php');
  require_once('data/common.php');

  

	$data = get_json();

	switch ($_SERVER['REQUEST_METHOD']) {
	  case 'GET':		
			GetAll($data);
            break;
     case 'POST':		
            ActualizarPrecios($data);
            break;            	
	  default:
	  	    http_response_code(405); 
	}
  
    function ActualizarPrecios($obj)
    {

        try
        {
           
            $db = new Database();            
            $id_productos = $obj->id_productos;
            $porcentaje = $obj->porcentaje;

            $sql  = "update productos set precio = ROUND(precio + ((precio*$porcentaje)/100), 2)
                     where id_producto in($id_productos)";

                 
            
            $db->query($sql);
            $db->execute(); 
            


            $sql = "insert into task_productos (tipo,id_sucursal,id_producto,codigo_producto,codigo_barra,descripcion,stock,precio,fecha,hora,procesado)
                    select 'M',
                    c.id_sucursal,
                    a.id_producto,
                    a.codigo_producto,
                    a.codigo_barra,
                    a.descripcion,
                    b.stock,
                    a.precio,
                    CURDATE(),
                    CURTIME(),
                    0	
                    from productos a inner join stock b
                    on a.id_producto = b.id_producto
                        inner join sucursales c
                    on c.id_sucursal = b.id_sucursal              
                    where a.id_producto in ($id_productos)";
            
            $db->query($sql);
            $db->execute();

            jsonMsg(array('status' => "OK"));
        } 
        catch (Exception $e) 
        {				
            jsonError($e->getMessage());
        }	
        finally {
            $db = null;
        }

    }

	function GetAll($obj)
	{
		
   
    
		try
        {
           
            
            if(strlen($obj->porcentaje)==0)
            {
                              
                jsonMsg(array(
                            'recordsTotal' => 0,
                            'recordsFiltered' => 0,
                            'data' => []
                        ));
                die();
            }

                                        
            $db = new Database(); //para todas la conexiones de esta pagina

            $x = "";
            
            if($obj->porcentaje>0)
            {
                $PCEN = $obj->porcentaje;  
                $x = ",ROUND(p.precio + ((p.precio*$PCEN)/100), 2)  as precio_calculado";
            }
            
            
           
           

            $sql ="SELECT p.id_producto, 
                          pt.descripcion as tipo, 
                          p.descripcion as producto,                         
                          p.precio,                          
                          pro.descripcion as proveedor,
                          p.id_producto_tipo,
                          p.id_proveedor
                          $x  
                from productos p  inner join productos_tipos pt 
                    on p.id_producto_tipo = pt.id_producto_tipo
                    inner join proveedores pro
                        on p.id_proveedor = pro.id_proveedor 
                where 1=1 ";  

            if(isset($obj->id_proveedor))
            {
                if($obj->id_proveedor>0)
                    $sql .= " and p.id_proveedor =".$obj->id_proveedor;
            }

            if(isset($obj->id_producto_tipo))
            {
                if($obj->id_producto_tipo>0)
                    $sql .= " and p.id_producto_tipo =".$obj->id_producto_tipo;
            }

            if(isset($obj->descripcion))
            {
                if(strlen($obj->descripcion)>0)
                    $sql .= " and p.descripcion like '%".$obj->descripcion."%'";
            }
            
            
            //die($sql);

            
            $db->query($sql);
                
            $resultado = $db->resultset();
            
            $recordsTotal = count($resultado);
            

            $Response = array(
                'recordsTotal' => $recordsTotal,
                'recordsFiltered' => $recordsTotal,
                'data' => $resultado
            );
            
            

            jsonMsg($Response);
        } 
        catch (Exception $e) 
        {				
            jsonError($e->getMessage());
        }	
        finally {
            $db = null;
        }	
	}





?>

