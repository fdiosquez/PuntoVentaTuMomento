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
            GuardarCambios($data);
            break;            	
	  default:
	  	    http_response_code(405); 
	}
  
    function GuardarCambios($obj)
    {
       
    }

	function GetAll($obj)
	{
		
   
    
		try
        {
           

                                        
            $db = new Database(); //para todas la conexiones de esta pagina
            
            $id_producto = $obj->id_producto;

            $sql ="SELECT a.id_stock, 
                            b.id_sucursal,
                            b.descripcion as sucursal, 
                            a.stock,
                            c.descripcion as producto 
                    FROM stock a inner JOIN sucursales b 
                    on a.id_sucursal = b.id_sucursal
                        inner join productos c
                        on c.id_producto  = a.id_producto
                where a.id_producto = $id_producto";

            
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

