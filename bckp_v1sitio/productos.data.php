<?php 

  header('Access-Control-Allow-Origin: *');
  header('Access-Control-Allow-Methods: POST, GET, DELETE, PUT, PATCH, OPTIONS');
  header('Content-Type: text/html; charset=utf-8');			

  require_once('data/class.database.php');
  require_once('data/common.php');

  

	$data = get_json();

	switch ($_SERVER['REQUEST_METHOD']) {
	  case 'GET':		
			GetAllProductos($data);
            break;
     case 'POST':		
            GuardarCambios($data);
            break;            	
	  default:
	  	    http_response_code(405); 
	}
  
    function GuardarCambios($obj)
    {
        try
        {
           
            $db = new Database(); 

            $accion           = $obj->accion;        
            $id_producto      = $obj->id_producto;
            $id_producto_tipo = $obj->id_producto_tipo;
            $descripcion      = $obj->descripcion;            
            $precio           = $obj->precio;            
            $codigo_barra     = $obj->codigo_barra;
            $codigo_producto  = $obj->codigo_producto;
            $id_proveedor = $obj->id_proveedor;

            switch($accion)
            {
              case "nuevo": 
                                      
                    $sql = "insert into productos (id_producto_tipo,descripcion,precio,activo,codigo_barra,codigo_producto,id_proveedor) 
                            values ('$id_producto_tipo','$descripcion','$precio','1','$codigo_barra','$codigo_producto','$id_proveedor')";
    
                    $db->query($sql);
                    $db->execute();
    
                    $id_producto = $db->lastInsertId();    
                    CreaStockPorSucursal($db,$id_producto);    
                    InformoProducto($db,$id_producto,"A");
    
    
                    $mensaje ="Producto agregado con exito!";
                    break;
              case "modificar":
                                      
                    
                    $sql = "update productos set id_producto_tipo='$id_producto_tipo',
                                                  descripcion='$descripcion',                                                  
                                                  precio='$precio',                                                  
                                                  codigo_barra='$codigo_barra',
                                                  codigo_producto='$codigo_producto',
                                                  id_proveedor='$id_proveedor'
                                                  where id_producto =  $id_producto";
                    $db->query($sql);
                    $db->execute();
    
                    InformoProducto($db,$id_producto,"M");
    
                    $mensaje ="Producto modificado con exito!";
                    break;
              case "eliminar":
    
                    /*
                    if(TieneRemitosAsociados($db,$id_producto))
                        throw new Exception("El producto no se puede eliminar, por tener remitos asociados!");
    
                    */
    
                    //PRIMERO INFORMO LA ELIMINACION
                    InformoProducto($db,$id_producto,"B");
    
                    //ELIMINO FISICAMENTE
                    $sql = "delete from productos where id_producto = $id_producto";
                    $mensaje ="Producto eliminado con exito!";
    
                    $db->query($sql);
                    $db->execute();                        
            }
            
           
            

            jsonMsg(array('status' => "ok"));
        } 
        catch (Exception $e) 
        {				
            jsonError($e->getMessage());
        }	
        finally {
            $db = null;
        }
    }

	function GetAllProductos($obj)
	{
		
   
    
		try
        {
           

                                        
            $db = new Database(); //para todas la conexiones de esta pagina
            
            $sql ="SELECT p.id_producto, 
                        pt.descripcion as tipo, 
                        p.descripcion as producto,                         
                        p.precio,
                        p.codigo_producto,
                        p.codigo_barra,
                        pro.descripcion as proveedor,
                        p.id_producto_tipo,
                        p.id_proveedor

                from productos p  inner join productos_tipos pt 
                    on p.id_producto_tipo = pt.id_producto_tipo
                    inner join proveedores pro
                        on p.id_proveedor = pro.id_proveedor 
                order by p.descripcion asc;";                            		
            
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

