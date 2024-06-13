<?php
	$current_section = "responsables";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $db = new Database(); //para todas la conexiones de esta pagina

  $id_proveedor = 0; // siempre es nuevo, salvo que venga un valor > 0
  $descripcion = "";  
  $email = "";
  $telefono = "";

  if(isset($_REQUEST["id_proveedor"]))
  {

    $id_proveedor = $_REQUEST["id_proveedor"];

    $sql ="SELECT * FROM proveedores WHERE id_proveedor = $id_proveedor";                            		
                                
    $db->query($sql);            
    $resultado = $db->resultset();

    foreach($resultado as $row) 
    {
        $descripcion = $row['DESCRIPCION'];        
        $telefono = $row['TELEFONO'];
    }
    $resultado = null;

  }

  //segun el id determino si es: 
  $accion =  ($id_proveedor == 0 ) ? "nuevo" : "modificar";

  


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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Proveedores <small> / Formulario de Provedores</small></h2>
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
          
          <div class="col-md-3">
            <!-- Website Overview -->
            <div class="panel panel-default">
                <div class="panel-heading main-color-bg">
                  <h3 class="panel-title"><?php  echo ($id_proveedor == 0 ? "Nuevo proveedor" : "Modificar proveedor"); ?></h3>
                </div>
                <div class="panel-body">
                     
                  
                    <form id="formulario" action="proveedores.php" method="post">
                        <input type="hidden" name="id_proveedor"  value="<?php echo $id_proveedor?>" />
                        <input type="hidden" name="accion"  value="<?php echo $accion;?>" />
                        
                      <p>
                        <label for="descripcion">Descripcion</label>
                        <input type="text" name="descripcion"  class="form-control" placeholder="Ingrese descripcion" value="<?php echo $descripcion;?>">
                      </p>
                     
                      <p>
                        <label for="descripcion">Teléfono</label>
                        <input type="text" name="telefono"  class="form-control" placeholder="" value="<?php echo $telefono;?>">
                      </p>
                   
                      <p>
                                <button type="button"  class="btn btn-default" onclick="location.href='proveedores.php';" >Volver</button>                        
                                <button type="submit" class="btn btn-primary" name="guardar">Guardar Cambios</button>
                      </p>
                      </form>
                  
                
                </div>
            </div>            
          </div>

        </div>
      </div>
    </section>

    
    <!-- Modals -->

    <!-- NUEVO RESPONSABLE -->
    <div class="modal fade" id="addCorralon" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  		<div class="modal-dialog" role="document">
    	<div class="modal-content">
      		
    	</div>
  	</div>
   </div>


    
    <script src="js/jquery-3.5.1.js"></script>    
    <script src="js/cdn_jquery.validate.js"></script>
    <script src="js/bootstrap.min.js"></script>    

  </body>
</html>

<script>
    $().ready(function() {
            // validate the comment form when it is submitted
            $("#formulario").validate({
                rules: {
                    descripcion: {
                        required: true,
                        minlength: 3
                    }
                },
                messages: {
                  descripcion: {
                        required: "Debes completarla descripcion",
                        minlength: "El nombre debe tener al menos 3 caracteres"
                    }
                    
                }
 
            });
        });
</script>


<?php  
  $db = null; //saco de memoria el objeto
?>