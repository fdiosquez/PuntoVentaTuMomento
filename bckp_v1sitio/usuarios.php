<?php
	$current_section = "usuarios";
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
        $id_usuario       = $_REQUEST["id_usuario"];
        $nombre_completo  = isset($_REQUEST["nombre_completo"])?$_REQUEST["nombre_completo"]:"";
        $usuario          = isset($_REQUEST["usuario"])?$_REQUEST["usuario"]:"";
        $password         = isset($_REQUEST["password"])?$_REQUEST["password"]:"";
        
        switch($accion)
        {
          case "nuevo": 

                if(ExisteUsuario($db,$usuario,""))                                  
                  throw new Exception("El Usuario $usuario ya existe, utilice otro nombre de usuario");
                
                $sql = "insert into usuarios (nombre_completo,usuario,password) values ('$nombre_completo','$usuario','$password')";                
                $mensaje ="Usuario agregado con exito!";
                break;
          case "modificar":

                if(ExisteUsuario($db,$usuario,$id_usuario))                                  
                  throw new Exception("El Usuario $usuario ya existe, utilice otro nombre de usuario");

                $sql = "update usuarios set nombre_completo='$nombre_completo',usuario='$usuario',password='$password' where id_usuario =  $id_usuario";                
                $mensaje ="Usuario modificado con exito!";
                break;
          case "eliminar": 

                if(TieneRemitosAsociados($db,$id_usuario))
                  throw new Exception("El usuario no se puede eliminar, por tener remitos asociados!");
                
                $sql = "delete from usuarios where id_usuario = $id_usuario";               
                $mensaje ="Usuario eliminado con exito!";
                
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

  function ExisteUsuario($db,$usuario,$id_usuario)
  {
    /**DETERMINA SI EXISTEN USUARIOS CON EL MISMO NOMBRE */
    $existe = false;

    $sql = "select count(u.id_usuario) as n from usuarios u where u.usuario = '$usuario'";

    if(strlen($id_usuario)>0)
    {
      $sql .= " and u.id_usuario != $id_usuario";
    }

    $db->query($sql);                       
    $resultado = $db->resultset();
    foreach($resultado as $row) 
    { 
      if($row["n"]>0)
        $existe = true;

    }

    return $existe;
  }


  function TieneRemitosAsociados($db,$id_usuario)
  {
      /**VERIFICA SI EL USUARIO QUE SE QUIERE ELIMINAR TIENE REMITOS ASOCIADOS */     
     $tiene = false;

     $sql = "select count(u.id_usuario) as n from usuarios u INNER JOIN remitos r where r.id_usuario = $id_usuario";
     $db->query($sql);                       
     $resultado = $db->resultset();
     foreach($resultado as $row) 
     { 
       if($row["n"]>0)
         $tiene = true;
 
     }
 
     return $tiene;
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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Usuarios <small> / Listado de usuarios</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="location.href='usuarios_formulario.php'">
                Nuevo Usuario      
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
                                <th>Nombre completo</th>
                                <th>Usuario</th>
                                <th>Password</th>                                
                                <th></th>                                              
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                            $sql ="SELECT * FROM usuarios where  es_admin IS NULL or es_admin = 0";                            		
                                
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                $id_usuario = $row['id_usuario'];

                                echo "<tr>";
                                echo "<td>".$id_usuario."</td>";
                                echo "<td>".$row['nombre_completo']."</td>";
                                echo "<td>".$row['usuario']."</td>";
                                echo "<td>**************</td>";                                
                                echo "<td>
                                        <a class='btn btn-default' onClick='Editar($id_usuario);'>Editar</a> 
                                        <a class='btn btn-danger' onClick=\"Eliminar($id_usuario);\">Eliminar</a></td>";
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