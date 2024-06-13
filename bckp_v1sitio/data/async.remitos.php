<?php
    session_start();
	require_once('class.database.php');	

    //si no existe la variable de session de productos lo crea
    if(!isset($_SESSION["PRODUCTOS_REMITOS"]))
        $_SESSION["PRODUCTOS_REMITOS"] = [];

    $accion = $_REQUEST["accion"];

    switch ($accion) 
	{
		case "agregar_producto":
                AgregarProducto();
			break;
		case "listar_productos":
			    ListarProducto();
			break;
		case "existe_producto_en_remito":
			    ExisteProductoEnRemito();
			break;
		case "eliminar_producto_en_remito":
                EliminarProductoEnRemito();			
			break;
		case "5":
			//TraerCorralon($obj->id_corralon);	
			break;
		
	}

    function AgregarProducto()
    {
        try
			{
				  $db = new Database();
				
                  
                  $id_producto = $_REQUEST["producto"];
                  $cantidad = $_REQUEST["cantidad"];

                  $producto = "";
                  $tipo ="";

				  $sql = 'SELECT p.id_producto, 
                                 p.descripcion as producto,
                                 pt.descripcion as tipo
                            FROM productos p inner join productos_tipos pt 
                                on p.id_producto_tipo = pt.id_producto_tipo
                            WHERE p.id_producto='.$id_producto;

                    $db->query($sql);                
                    $resultado = $db->resultset();

                    foreach($resultado as $row) 
                    {
                        $id_producto = $row['id_producto'];
                        $producto = $row['producto'];
                        $tipo =  $row['tipo'];                        
                    } 

                    

                    $Lista = $_SESSION["PRODUCTOS_REMITOS"];

                    $producto = array("id_producto" => $id_producto, "cantidad" => $cantidad,"tipo"=>$tipo,"descripcion"=>$producto);
                    $Lista[] = $producto;

                    $_SESSION["PRODUCTOS_REMITOS"] = $Lista;

                    

                    

				    $db->SimpleSendData("status","OK");
				
			}catch(Exception $e)
			{
				$db->SimpleSendData("status",$e->getMessage());
			}
			finally {
			  $db = null;
			}

    }

    function ListarProducto()
    {
               
        $count = count($_SESSION["PRODUCTOS_REMITOS"]);

        //estructura para la grilla
        $response = array(
            'recordsTotal' => $count,
            'recordsFiltered' => $count,
            'data' => $_SESSION["PRODUCTOS_REMITOS"]
        );

        header('Content-Type: application/json');
        echo json_encode($response);	
        http_response_code(200);

    }

    function ExisteProductoEnRemito()
    {
        $db = new Database();                        
        $id_producto = $_REQUEST["producto"];
        $existe = false;
        foreach($_SESSION["PRODUCTOS_REMITOS"] as $row) 
        {
            if($id_producto == $row['id_producto'])
            {
                $existe = true;
                break;
            }                             
        } 

        $db->SimpleSendData("existe",$existe);
        $db = null;
    }


    function EliminarProductoEnRemito()
    {
        $db = new Database();                        
        $id_producto = $_REQUEST["producto"];        
        $nueva_lista = [];
        
        foreach($_SESSION["PRODUCTOS_REMITOS"] as $row) 
        {
            if($id_producto != $row['id_producto'])
            {                
                $nueva_lista[] = $row;                
            }                             
        }

        $_SESSION["PRODUCTOS_REMITOS"] = $nueva_lista;
                
        $db->SimpleSendData("borrado",true);
        $db = null;
    }

?>