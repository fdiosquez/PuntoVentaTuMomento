<?php
session_start();
require('layout.constantes.php');
if(isset($_REQUEST["verificar"]))
{
	require_once('data/class.database.php');
	
	
	$user = $_REQUEST["user"];
	$pwd = $_REQUEST["password"];
	
	$db = new Database();
	$sql ="SELECT * FROM usuarios where usuario=:usuario  and password =:password";
	
	$db->query($sql);
	$db->bind(':usuario',$user);
	$db->bind(':password',$pwd);
				
	$resultado = $db->resultset();
	
	if(count($resultado)>0)
	{
		$row = $resultado[0];		
		$_SESSION['usuario'] = $row["nombre_completo"];
    $_SESSION['id_usuario'] = $row["id_usuario"];

    $sql ="SELECT valor FROM configuracion WHERE constante = 'USAR_NRO_REMITO_EXTERNO'";	
	  $db->query($sql);
    $resultado = $db->resultset();
    if(count($resultado)>0)
    {
        $row = $resultado[0];		
       if(trim($row["valor"])=="1")  
       {          
          $_SESSION['ID_REMITO_FIELD'] = "remito_preimpreso";       
       }               
       else  
       {        
          $_SESSION['ID_REMITO_FIELD'] = "id_remito";
       }     
          
        //ALTER TABLE `usuarios` ADD `ultimo_acceso` VARCHAR(20) NULL AFTER `password`;
        
        $sql = "update usuarios set ultimo_acceso = NOW() where id_usuario = ".$_SESSION['id_usuario'];
        $db->query($sql);        
        $db->execute();


    } 
    else    
        die("Error: Revisar tabla configuración");
    

    

		header("Location:index.php");
	}
	
}


if(isset($_REQUEST["exit"]))
{
	session_destroy();	
}



?>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Sistema de Remitos</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <script src="js/cdn_ckeditor.js"></script>
  </head>
  <body>

    <nav class="navbar navbar-default">
      <div class="container">
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

        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <header id="header">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1 class="text-center"> Area de Administración</h1>
          </div>
        </div>
      </div>
    </header>

    <section id="main">
      <div class="container">
        <div class="row">
          <div class="col-md-4 col-md-offset-4">
            <form id="login" action="login.php" class="well" name="frmlogin">
                  <div class="form-group">
                    <label>Usuario</label>
                    <input type="text" name="user" class="form-control" placeholder="Ingrese Usuario">
                  </div>
                  <div class="form-group">
                    <label>Password</label>
                    <input type="password" name="password" class="form-control" placeholder="Password">
                  </div>
                  <button type="submit" name="verificar"  class="btn btn-default btn-block">Login</button>
              </form>
              
          </div>
        </div>
        
        <p class = "text-center small"><?php echo VERSION_APP;?></p>
      </div>
    </section>


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/ajax_jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
  </body>
</html>
