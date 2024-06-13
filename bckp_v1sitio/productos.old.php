<?php
	$current_section = "productos";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');
  require_once('data/common.php');

  $mensaje = ""; //usados para las alertas en js
  $db = new Database(); //para todas la conexiones de esta pagina

  if(isset($_REQUEST["accion"]))
  {
  
    try
			{

        $accion           = $_REQUEST["accion"];        
        $id_producto      = $_REQUEST["id_producto"];
        $id_producto_tipo = isset($_REQUEST["id_producto_tipo"])?$_REQUEST["id_producto_tipo"]:"";
        $descripcion      = isset($_REQUEST["descripcion"])?$_REQUEST["descripcion"]:"";
        $stock            = isset($_REQUEST["stock"])?$_REQUEST["stock"]:"";
        $precio           = isset($_REQUEST["precio"])?$_REQUEST["precio"]:"";
        $activo           = isset($_REQUEST["activo"])?$_REQUEST["activo"]:"";
        $codigo_barra     = isset($_REQUEST["codigo_barra"])?$_REQUEST["codigo_barra"]:"";
        $codigo_producto  = isset($_REQUEST["codigo_producto"])?$_REQUEST["codigo_producto"]:"";
        $id_proveedor = isset($_REQUEST["id_proveedor"])?$_REQUEST["id_proveedor"]:"0";
        
        switch($accion)
        {
          case "nuevo": 
                /*
                if(ExisteCodigoProducto($db,$codigo_producto,0))
                  throw new Exception("El  código de producto ($codigo_producto) ya existe en la base de datos");
                */

                $sql = "insert into productos (id_producto_tipo,descripcion,stock,precio,activo,codigo_barra,codigo_producto,id_proveedor) 
                        values ('$id_producto_tipo','$descripcion','$stock','$precio','1','$codigo_barra','$codigo_producto','$id_proveedor')";

                $db->query($sql);
                $db->execute();

                $id_producto = $db->lastInsertId();

                CreaStockPorSucursal($db,$id_producto);

                InformoProducto($db,$id_producto,"A");


                $mensaje ="Producto agregado con exito!";
                break;
          case "modificar":
                /*if(ExisteCodigoProducto($db,$codigo_producto,$id_producto))
                  throw new Exception("El  código de producto ($codigo_producto) ya existe en la base de datos");*/

                $sql = "update productos set id_producto_tipo='$id_producto_tipo',
                                              descripcion='$descripcion',
                                              stock='$stock',
                                              precio='$precio',
                                              activo='$activo',
                                              codigo_barra='$codigo_barra',
                                              codigo_producto='$codigo_producto',
                                              id_proveedor='$id_proveedor'
                                              where id_producto =  $id_producto";
                $db->query($sql);
                $db->execute();

                InformoProducto($db,$id_producto,"M");

                $mensaje ="Producto modificado con exito!";
                break;
          case "eliminar":

                /*
                if(TieneRemitosAsociados($db,$id_producto))
                    throw new Exception("El producto no se puede eliminar, por tener remitos asociados!");

                */

                //PRIMERO INFORMO LA ELIMINACION
                InformoProducto($db,$id_producto,"B");

                //ELIMINO FISICAMENTE
                $sql = "delete from productos where id_producto = $id_producto";
                $mensaje ="Producto eliminado con exito!";

                $db->query($sql);
                $db->execute();



        }
        
				
				
			}
      catch(Exception $e)
			{
				$mensaje = $e->getMessage();
			}
			
      
  }

  

  function ExisteCodigoProducto($db,$codigo_producto,$id_producto)
  {
    /**DETERMINA SI EXISTEN USUARIOS CON EL MISMO NOMBRE */
    $existe = false;

    $sql = "select count(id_producto) as n from productos  where codigo_producto = '$codigo_producto'";

    if(strlen($id_producto)>0)
    {
      $sql .= " and id_producto != $id_producto";
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


  function TieneRemitosAsociados($db,$id_producto)
  {
      /**VERIFICA SI EL USUARIO QUE SE QUIERE ELIMINAR TIENE REMITOS ASOCIADOS */     
     $tiene = false;

     $sql = "select count(id_remito_detalle) as n from remitos_detalle where id_producto = $id_producto";
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
    <title><?php echo TITULO;?> | Productos</title>
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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Productos <small> / Listado de Productos</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="location.href='productos_formulario.php'">
                Nuevo Producto     
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
                                <th>Código</th>                                
                                <th>Producto</th>
                                <th>Rubro</th>                                
                                <th>C.Barra</th>
                                <th>Stock</th>
                                <th>Precio</th>
                                <th>Activo</th>                                 
                                <th></th>                                              
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                            $sql ="SELECT p.id_producto, 
                                          pt.descripcion as tipo, 
                                          p.descripcion as producto, 
                                          p.stock, 
                                          p.precio, 
                                          (CASE WHEN p.activo=1 THEN 'SI' ELSE 'NO' END) AS activo,
                                          p.codigo_producto,
                                          p.codigo_barra
                                  from productos p  inner join productos_tipos pt 
                                        on p.id_producto_tipo = pt.id_producto_tipo 
                                  order by p.descripcion asc;";                            		
                                
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                $id_producto = $row['id_producto'];

                                echo "<tr>";
                                echo "<td>".$row['codigo_producto']."</td>";
                                echo "<td>".$row['producto']."</td>";
                                echo "<td>".$row['tipo']."</td>";                                
                                echo "<td>".$row['codigo_barra']."</td>";
                                echo "<td>".$row['stock']."</td>";                                
                                echo "<td>".$row['precio']."</td>";
                                echo "<td>".$row['activo']."</td>";                                
                                echo "<td>
                                        <a class='btn btn-default' onClick='Editar($id_producto);'>Editar</a> 
                                        <a class='btn btn-danger' onClick=\"Eliminar($id_producto);\">Eliminar</a></td>";
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
      <input type="hidden" name="id_producto" id="id_producto"  value="" />
      <input type="hidden" name="accion" id="accion"   value="" />
    </form>
        

    
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/cdn_jquery.dataTables.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.blockUI.js"></script>

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
            },
            order: [[1, 'asc']]
        });
        
        

    });

    function Editar(id_producto)
    {
      $("#id_producto").val(id_producto);                    
      $('#formulario').attr('action', "productos_formulario.php").submit();
    }

    function Eliminar(id_producto)
    {

      if(confirm("¿Seguro que desea eliminar el producto Nro " + id_producto + " ?"))
      {
        $("#id_producto").val(id_producto); 
        $("#accion").val("eliminar"); 
        $('#formulario').attr('action', "productos.php").submit();
      }
      
    }

</script>

<?php
  $db = null; //saco de memoria el objeto
?>