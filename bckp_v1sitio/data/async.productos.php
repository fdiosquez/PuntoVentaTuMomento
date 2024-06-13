<?php
    session_start();
	require_once('class.database.php');	
    require_once('common.php');

 
    $accion = $_REQUEST["accion"];

    switch ($accion) 
	{
		case "actualizar_stock":
                ActualizarStock();
			break;					
	}

    function ActualizarStock()
    {
        try
			{
				  $db = new Database();
				
                  
                  $id_stock = $_REQUEST["id_stock"];
                  $stock = $_REQUEST["stock"];
                  $id_sucursal = $_REQUEST["id_sucursal"];
                  $id_producto = $_REQUEST["id_producto"];
                  

				  $sql = "update stock set stock = $stock where id_stock = $id_stock and id_sucursal = $id_sucursal";

                  $db->query($sql);
                  $db->execute();                                         
                   
                  
                  InformoProducto($db,$id_producto,"M",$id_sucursal);


				   $db->SimpleSendData("status","OK");
				
			}catch(Exception $e)
			{
				$db->SimpleSendData("status",$e->getMessage());
			}
			finally {
			  $db = null;
			}

    }

    

?>