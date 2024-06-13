<?php
	$current_section = "responsables";
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
        $id_responsable      = $_REQUEST["id_responsable"];        
        $descripcion          = isset($_REQUEST["descripcion"])?$_REQUEST["descripcion"]:"";        
        $email          = isset($_REQUEST["email"])?$_REQUEST["email"]:"";        
        $telefono          = isset($_REQUEST["telefono"])?$_REQUEST["telefono"]:"";        
        
        
        switch($accion)
        {
          case "nuevo": 
                $sql = "insert into responsables (descripcion,email,telefono) values ('$descripcion','$email','$telefono')";
                $mensaje ="Cliente agregado con exito!";
                break;
          case "modificar":
                $sql = "update responsables set descripcion='$descripcion',email='$email',telefono='$telefono' where id_responsable =  $id_responsable";
                $mensaje ="Cliente modificado con exito!";
                break;
          case "eliminar": 
                $sql = "delete from responsables where id_responsable = $id_responsable";
                $mensaje ="Cliente eliminado con exito!";
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
    <title><?php echo TITULO;?> | Responsables</title>
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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Clientes <small> / Listado de Clientes</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="location.href='responsables_formulario.php'">
                Nuevo Cliente     
               </button>
            </div>
            
          </div>
        </div>
      </div>
    </header>

   

    <section id="main">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-2 hidden-xs hidden-sm">
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
                                <th>Nro</th>
                                <th>Descripción</th>                                                             
                                <th>E-mail</th>
                                <th>Teléfono</th>
                                <th></th>                                              
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                            $sql ="SELECT * FROM responsables";                            		
                                
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                $id_responsable = $row['id_responsable'];

                                echo "<tr>";
                                echo "<td>".$id_responsable."</td>";                                
                                echo "<td>".$row['descripcion']."</td>";                                
                                echo "<td>".$row['email']."</td>";
                                echo "<td>".$row['telefono']."</td>";
                                echo "<td>
                                        <a class='btn btn-default' onClick='Editar($id_responsable);'>Editar</a> 
                                        <a class='btn btn-danger' onClick=\"Eliminar($id_responsable);\">Eliminar</a></td>";
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
      <input type="hidden" name="id_responsable" id="id_responsable"  value="" />
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

    function Editar(id_responsable)
    {
      $("#id_responsable").val(id_responsable);                    
      $('#formulario').attr('action', "responsables_formulario.php").submit();
    }

    function Eliminar(id_responsable)
    {

      if(confirm("¿Seguro que desea eliminar el responsable Nro " + id_responsable + " ?"))
      {
        $("#id_responsable").val(id_responsable); 
        $("#accion").val("eliminar"); 
        $('#formulario').attr('action', "responsables.php").submit();
      }
      
    }

</script>

<?php
  $db = null; //saco de memoria el objeto
?>