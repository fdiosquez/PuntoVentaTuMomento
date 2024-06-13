<?php


function InformoProducto($db,$id_producto,$tipo,$id_sucursal=0)
  {
      $sql = "insert into task_productos (tipo,id_sucursal,id_producto,codigo_producto,codigo_barra,descripcion,stock,precio,fecha,hora,procesado)
              select '$tipo',
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
              where a.id_producto = $id_producto";
        
        if($id_sucursal>0)
            $sql .= " and c.id_sucursal = $id_sucursal";

    $db->query($sql); 
    $db->execute();
  }

  function CreaStockPorSucursal($db,$id_producto)
  {
      $sql = " insert into stock (id_producto,id_sucursal,stock) 
                select $id_producto,a.id_sucursal,0
                from sucursales a;";

      $db->query($sql); 
      $db->execute();
  }

  function get_json()
    {
        try
        {

           

            switch ($_SERVER['REQUEST_METHOD']) {
                case 'GET':		
                    if(empty($_GET)) //si viene por postman
                        $string =  file_get_contents('php://input');
                    else
                        $string = json_encode($_GET);//vino por jquery
                  break;
               /* case 'DELETE':
                    $string =  file_get_contents('php://input');
                    echo "-->".$string;
                    die();
                  break;		*/
                default:
                    $string =  file_get_contents('php://input');
              }
          
            if(!$string)
            {
                http_response_code(403);
                die();
            }    
                        
            // decode the JSON data
            $result = json_decode($string);
             
          
            // switch and check possible JSON errors
            switch (json_last_error()) {
                case JSON_ERROR_NONE:
                    $error = ''; // JSON is valid // No error has occurred
                    break;
                case JSON_ERROR_DEPTH:
                    $error = 'The maximum stack depth has been exceeded.';
                    break;
                case JSON_ERROR_STATE_MISMATCH:
                    $error = 'Invalid or malformed JSON.';
                    break;
                case JSON_ERROR_CTRL_CHAR:
                    $error = 'Control character error, possibly incorrectly encoded.';
                    break;
                case JSON_ERROR_SYNTAX:
                    $error = 'Syntax error, malformed JSON.';
                    break;
                // PHP >= 5.3.3
                case JSON_ERROR_UTF8:
                    $error = 'Malformed UTF-8 characters, possibly incorrectly encoded.';
                    break;
                // PHP >= 5.5.0
                case JSON_ERROR_RECURSION:
                    $error = 'One or more recursive references in the value to be encoded.';
                    break;
                // PHP >= 5.5.0
                case JSON_ERROR_INF_OR_NAN:
                    $error = 'One or more NAN or INF values in the value to be encoded.';
                    break;
                case JSON_ERROR_UNSUPPORTED_TYPE:
                    $error = 'A value of a type that cannot be encoded was given.';
                    break;
                default:
                    $error = 'Unknown JSON error occured.';
                    break;
            }

            if ($error !== '') {
                throw new Exception($error);                	
            }   

         


            // everything is OK
            return $result;
        } 
        catch (Exception $e) 
        {				
            jsonError ($e->getMessage());
            die();
        }	


    }

    function jsonError ($value)
    {
        $jsondata = array();
        $jsondata["Error"] = $value;
        Header('Content-type: application/json; charset=utf-8');
        echo json_encode($jsondata);		
        http_response_code(400);
    }

    function jsonMsg ($data)
    {
        header('Content-Type: application/json');
        echo json_encode($data);	
        http_response_code(200);
    }


?>
