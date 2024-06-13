<?php
	$current_section = "remitos";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $mensaje = ""; //usados para las alertas en js
  $db = new Database(); //para todas la conexiones de esta pagina


  if(isset($_REQUEST["accion"]))
  {
  
    try
			{

        $accion           = $_REQUEST["accion"];        
      
        switch($accion)
        {
          case "nuevo_remito":
                
            $id_responsable = $_REQUEST["id_responsable"];
            $id_usuario = $_SESSION['id_usuario'];
            $fecha = $_REQUEST["fecha"];
            $destino = $_REQUEST["destino"];
            $remito_preimpreso = $_REQUEST["remito_preimpreso"];
            $observaciones = $_REQUEST["observaciones"];

            $sql = "insert into remitos (id_responsable,id_usuario,fecha,destino,remito_preimpreso,observaciones,activo) 
                    values ($id_responsable,$id_usuario,'$fecha','$destino','$remito_preimpreso','$observaciones',1)";

            $db->query($sql);
            $db->execute();

            $id_remito = $db->lastInsertId();

            foreach($_SESSION["PRODUCTOS_REMITOS"] as $row) 
            {

                $id_producto = $row["id_producto"];
                $cantidad = $row["cantidad"];
                $sql = "insert into remitos_detalle (id_remito,id_producto,cantidad) values ($id_remito,$id_producto,$cantidad)";
                $db->query($sql);
                $db->execute();                              
            }

            // con esto afecto el stock de los productos que participan del remito
            $sql = "update productos as p inner join remitos_detalle as rd 
                        on p.id_producto = rd.id_producto 
                    SET p.stock =  (CASE WHEN p.stock - rd.cantidad < 0 THEN 0 ELSE  p.stock - rd.cantidad END) 
                    where rd.id_remito = $id_remito";
            $db->query($sql);
            $db->execute();

            $_SESSION["PRODUCTOS_REMITOS"] = []; //elimino todos los productos

            $mensaje ="El remito fue generado con exito!";
            break;  
        }
        
				$db->query($sql);
        $db->execute();
				
			}
      catch(Exception $e)
			{
				$mensaje = $e->getMessage();
			}
			

    
    

  }


?>

                    
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><?php echo TITULO;?> | Usuarios</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet"> 
    <link href="https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css" rel="stylesheet">   
  </head>
  <body>

    <nav class="navbar navbar-default">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#"><?php echo TITULO_APP;?></a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav hidden-md hidden-lg hidden-sm">
            <?php Layout::CreateMenuSuperior("Dashboard");?>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            <?php Layout::CreateLogInfo();?>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <header id="header">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-10">
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Remitos <small> / Listado de remitos</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="location.href='remitos_formulario.php'">
                Nuevo Remito      
               </button>
            </div>
            
          </div>
        </div>
      </div>
    </header>

   

    <section id="main">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-2  hidden-xs hidden-sm">
            <div class="list-group">
              <?php Layout::CreateMenuIzquierdo($current_section);?>
            </div>
 
          </div>
          
          <div class="col-md-10">
            <!-- Website Overview -->
            <div class="panel panel-default">
              <div class="panel-heading main-color-bg">
                <h3 class="panel-title"></h3>
              </div>
                <div class="panel-body">
                    <div class="table-responsive" >
                        <table id="example" class="display " style="width:100%">
                        <thead>
                            <tr>
                                <th>Nro Remito</th>
                                <th>Fecha</th>
                                <th>Alta</th>
                                <th>Responsable</th>                                                                
                                <th>Destino</th>
                                <th>Nro Pre-Impreso</th> 
                                <th>Observaciones</th>                      
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                            $sql ="SELECT r.id_remito, 
                                          res.descripcion as responsable, 
                                          u.nombre_completo as creado, 
                                          r.fecha, 
                                          r.destino, 
                                          r.remito_preimpreso, 
                                          r.observaciones 
                                    FROM remitos as r inner join responsables as res 
                                        on r.id_responsable = res.id_responsable 
                                          inner join usuarios as u 
                                        on r.id_usuario = u.id_usuario
                                    ";                            		
                                
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                $id_remito = $row[$_SESSION['ID_REMITO_FIELD']];
                                
                                echo "<tr>";
                                echo "<td>".$id_remito."</td>";
                                echo "<td>".$row['fecha']."</td>";
                                echo "<td>".$row['creado']."</td>";
                                echo "<td>".$row['responsable']."</td>";
                                echo "<td>".$row['destino']."</td>";
                                echo "<td>".$row['remito_preimpreso']."</td>";
                                echo "<td>".$row['observaciones']."</td>";
                                echo "<td>
                                        <a class='btn btn-default' href='remitos_visualizar.php?id=".$row["id_remito"]."' Target='_blank'>Visualizar</a> 
                                      </td>";
                                echo "</tr>";
                            }
                            
                            
                        ?>                                               
                        </tbody>                    
                        </table>
                    </div>    


                </div>
            </div>

          </div>
        </div>
      </div>
    </section>
    
    <!--FORM OCULTO PARA ACCIONES-->
    <form id="formulario" action="" method="post">
      <input type="hidden" name="id_usuario" id="id_usuario"  value="" />
      <input type="hidden" name="accion" id="accion"   value="" />
    </form>
        

    
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/cdn_jquery.dataTables.min.js"></script>
    <script src="js/bootstrap.min.js"></script>    

  </body>
</html>

<script>
    $(document).ready(function() 
    {        	
       var mensaje = "<?php echo $mensaje;?>";  
       if(mensaje.length>0)
       {
          alert(mensaje);
       }
      
      $('#example').DataTable({
            language: { 
                "lengthMenu": "Mostrar _MENU_ filas por página",
                "zeroRecords": "Sin resultados",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "Sin resultados",
                "infoFiltered": "(Filtrando _MAX_ totales)",
                "search": "Buscar",
                "oPaginate": {
                "sFirst": "Primera página", 
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Última página" 
                },            
            }
        });
        
        

    });

    function Editar(id_usuario)
    {
      $("#id_usuario").val(id_usuario);                    
      $('#formulario').attr('action', "usuarios_formulario.php").submit();
    }

    function Eliminar(id_usuario)
    {

      if(confirm("¿Seguro que desea eliminar el usuario Nro " + id_usuario + " ?"))
      {
        $("#id_usuario").val(id_usuario); 
        $("#accion").val("eliminar"); 
        $('#formulario').attr('action', "usuarios.php").submit();
      }
      
    }

</script>

<?php
  $db = null; //saco de memoria el objeto
?>