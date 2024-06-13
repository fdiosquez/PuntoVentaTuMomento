<?php
	$current_section = "usuarios";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $db = new Database(); //para todas la conexiones de esta pagina

  $id_usuario = 0; // siempre es nuevo, salvo que venga un valor > 0
  $nombre_completo = "";
  $usuario = "";  

  if(isset($_REQUEST["id_usuario"]))
  {

    $id_usuario = $_REQUEST["id_usuario"];

    $sql ="SELECT * FROM usuarios WHERE id_usuario = $id_usuario";                            		
                                
    $db->query($sql);            
    $resultado = $db->resultset();

    foreach($resultado as $row) 
    {
        $nombre_completo = $row['nombre_completo'];
        $usuario = $row['usuario'];        
    }
    $resultado = null;

  }

  //segun el id determino si es: 
  $accion =  ($id_usuario == 0 ) ? "nuevo" : "modificar";

  


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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Usuarios <small> / Listado de usuarios</small></h2>
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
                  <h3 class="panel-title"><?php  echo ($id_usuario == 0 ? "Nuevo Usuario" : "Modificar Usuario"); ?></h3>
                </div>
                <div class="panel-body">
                     
                  
                    <form id="formulario" action="usuarios.php" method="post">
                        <input type="hidden" name="id_usuario"  value="<?php echo $id_usuario?>" />
                        <input type="hidden" name="accion"  value="<?php echo $accion;?>" />
                        
                      <p>
                        <label for="nombre_completo">Nombre Completo</label>
                        <input type="text" name="nombre_completo"  class="form-control" placeholder="Ingrese Razón Social" value="<?php echo $nombre_completo;?>">
                      </p>
                      <p>
                          <label for="usuario">Usuario</label>
                                  <input type="text" name="usuario" class="form-control" value="<?php echo $usuario;?>">
                      </p>
                      <p>
                          <label>Password</label>
                          <input type="text" id="password" name="password" class="form-control" >
                      </p>
                      <p>
                          <label>Confirma Password</label>
                          <input type="text" name="password2" class="form-control" >
                      
                      </p>
                      <p>
                                <button type="button"  class="btn btn-default" onclick="location.href='usuarios.php';" >Volver</button>                        
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

    <!-- NUEVO USUARIO -->
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

       jQuery.validator.addMethod("noSpace", function(value, element) { 
       return value.indexOf(" ") < 0 && value != ""; 
       }, "No debe haber espacio en el campo");

    $().ready(function() {
            // validate the comment form when it is submitted
            $("#formulario").validate({
                rules: {
                    nombre_completo: {
                        required: true,
                        minlength: 3
                    },
                    usuario: {
                        required: true,
                        minlength: 5,
                        noSpace: true                     
                        
                    },
                    password: {
                      required: true,                      
                    },
                    password2: {
                      required: true,
                      equalTo: "#password"
                    }
                },
                messages: {
                  nombre_completo: {
                        required: "Debes completar el nombre",
                        minlength: "El nombre debe tener al menos 3 caracteres"
                    },
                    usuario: {
                        required: "El campo usuario es obligatorio",
                        minlength: "El campo usuario debe tener al menos 5 caracteres"
                        
                    },                    
                    password: {
                      required: "El password es obligatorio",                      
                    },
                    password2: {
                      required: "La confirmación del password es obligatorio",
                      equalTo: "Los passwords no coinciden"
                    }
                }
 
            });
        });
</script>


<?php  
  $db = null; //saco de memoria el objeto
?>