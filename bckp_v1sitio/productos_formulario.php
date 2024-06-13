<?php
	$current_section = "productos";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $db = new Database(); //para todas la conexiones de esta pagina

  $id_producto = 0; // siempre es nuevo, salvo que venga un valor > 0
  $id_producto_tipo = "0";
  $id_proveedor = 0;
  $descripcion = "";
  $stock = "";
  $precio = "";
  $activo = "";
  $codigo_barra = "";
  $codigo_producto= "";


  if(isset($_REQUEST["id_producto"]))
  {

    $id_producto = $_REQUEST["id_producto"];

    $sql ="SELECT * FROM productos WHERE id_producto = $id_producto";                            		
                                
    $db->query($sql);            
    $resultado = $db->resultset();

    foreach($resultado as $row) 
    {
        $id_producto_tipo = $row['id_producto_tipo'];
        $id_proveedor = $row['id_proveedor'];
        $codigo_producto = $row['codigo_producto'];
        $codigo_barra = $row['codigo_barra'];       
        $descripcion = $row['descripcion']; 
        $stock = $row['stock'];
        $precio = $row['precio'];
        $activo = $row['activo'];       
    }
    $resultado = null;

  }

  //segun el id determino si es: 
  $accion =  ($id_producto == 0 ) ? "nuevo" : "modificar";

  


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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Productos <small> / Formulario de productos</small></h2>
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
          
          <div class="col-md-4">
            <!-- Website Overview -->
            <div class="panel panel-default">
                <div class="panel-heading main-color-bg">
                  <h3 class="panel-title"><?php  echo ($id_producto == 0 ? "Nuevo Producto" : "Modificar Producto"); ?></h3>
                </div>
                <div class="panel-body">
                     
                  
                    <form id="formulario" name="formulario" action="productos.php" method="post">                      
                        <input type="hidden" name="id_producto"  value="<?php echo $id_producto?>" />
                        <input type="hidden" name="accion"  value="<?php echo $accion;?>" />
                        
                      <p>                                                
                      <label for="id_producto_tipo">Rubro producto</label> 
                      <select class="form-control" name="id_producto_tipo" id="id_producto_tipo">
                      <?php 
                        $sql = 'SELECT * from productos_tipos';
                        $db->query($sql);
                    
                        $resultado = $db->resultset();

                        if($id_producto==0)
                          echo "<option value='0' selected> << Seleccione Rubro >> </option>";
                        else
                          echo "<option value='0'> << Seleccione Rubro >> </option>";

                        foreach($resultado as $row) 
                        {
                            $sel = ($id_producto_tipo == $row['id_producto_tipo']) ? " selected" : "";
                            echo "<option value='".$row['id_producto_tipo']."' ".$sel.">".$row['descripcion']."</option>";                                            
                        } 
                        
                        $resultado = null;
                      
                      ?>                                                                         
                       </select>
                       </p>
                      <p>  
                        <label for="descripcion">Código Producto</label>   
                        <input type="text" name="codigo_producto"  class="form-control" placeholder="" value="<?php echo $codigo_producto;?>">
                      </p>
                      <p>  
                        <label for="descripcion">Código Barra</label>   
                        <input type="text" name="codigo_barra"  class="form-control" placeholder="" value="<?php echo $codigo_barra;?>">
                      </p>
                      <p>  
                        <label for="descripcion">Producto</label>   
                        <input type="text" name="descripcion"  class="form-control" placeholder="Ingrese producto" value="<?php echo $descripcion;?>">
                      </p>
                      <p>
                          <label for="stock">Stock</label>
                                  <input type="text" name="stock" class="form-control" value="<?php echo $stock;?>">
                      </p>
                      <p>
                          <label for="precio">Precio</label>
                                  <input type="number" name="precio" class="form-control" value="<?php echo $precio;?>">
                      </p>
                      <p>
                          <label for="activo">Activo</label>
                          <select class="form-control" name="activo" id="activo"> 
                          <option value="1" selected>SI</option>
                          <option value="0">NO</option>                                                                                       
                          </select>
                                  
                      </p>
                          
                      <p>
                          <label for="activo">Proveedor</label>
                          <select class="form-control" name="id_proveedor" id="id_proveedor">                                                                                                         
                          <?php 
                            $sql = 'SELECT * from proveedores';
                            $db->query($sql);
                        
                            $resultado = $db->resultset();

                            if($id_proveedor==0)
                              echo "<option value='0' selected> << Seleccione Proveedor >> </option>";
                            else
                              echo "<option value='0'> << Seleccione Rubro >> </option>";

                            foreach($resultado as $row) 
                            {
                                $sel = ($id_proveedor == $row['ID_PROVEEDOR']) ? " selected" : "";
                                echo "<option value='".$row['ID_PROVEEDOR']."' ".$sel.">".$row['DESCRIPCION']."</option>";                                            
                            } 
                            
                            $resultado = null;
                          
                          ?>
                          </select>                                  
                      </p>
                      <p>
                                <button type="button"  class="btn btn-default" onclick="location.href='productos.php';" >Volver</button>                        
                                <button type="submit" class="btn btn-primary" name="guardar">Guardar Cambios</button>
                      </p>
                      </form>
                  
                
                </div>
            </div>            
          </div>
          
          <!--STOCK-->
          <div class="col-md-6">
            <!-- Website Overview -->
            <div class="panel panel-default">
                <div class="panel-heading main-color-bg">
                  <h3 class="panel-title">Stock por sucursal</h3>
                </div>
                <div class="panel-body">
                     
                  
                    <div class="table-responsive" >
                        <table id="tblStock" class="display " style="width:100%">
                        <thead>
                            <tr>
                                <th>Sucursal</th>                                
                                <th>Stock</th>                                  
                                <th></th>                                              
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                            $sql ="SELECT a.id_stock, 
                                          b.id_sucursal,
                                          b.descripcion as sucursal, 
                                          a.stock 
                                    FROM stock a inner JOIN sucursales b 
                                    on a.id_sucursal = b.id_sucursal 
                                 where a.id_producto = $id_producto";                            		
                                
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                $id_stock = $row['id_stock'];
                                $stock = $row['stock'];
                                $id_sucursal = $row['id_sucursal'];
                                

                                echo "<tr>";
                                echo "<td>".$row['sucursal']."</td>";
                                echo "<td>$stock</td>";                                  
                                echo "<td>
                                        <a class='btn btn-default' onClick=\"Editar($id_stock,'$stock',$id_sucursal);\">Editar</a>
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
          <!---->


        </div>
      </div>
    </section>

    
    <!-- Modals -->

    <!-- STOCK-->
    <div class="modal fade" id="modalStock" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">    
  		<div class="modal-dialog" role="document">
            <div class="modal-content">
                  <form id="frmStock" name="frmStock" action="remitos.php" method="post">
                      <input type="hidden" name="id_stock" id="id_stock"  value="" />
                      <input type="hidden" name="id_sucursal" id="id_sucursal"  value="" />                      

                      <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Stock</h4>
                      </div>

                      <div class="modal-body">
                          <div class="form-group">
                            <label>Ingrese Stock</label>
                            <input type="number" name="stock" id="stock"  class="form-control" >
                            
                          </div>                              			          
                      </div>              

                      <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" onClick="ActualizarStock();" class="btn btn-primary">Guardar Cambios</button>
                      </div>
                  </form>                                     
            </div>
  	    </div>
   </div>


    
    <script src="js/jquery-3.5.1.js"></script>    
    <script src="js/cdn_jquery.validate.js"></script>
    <script src="js/bootstrap.min.js"></script>           
    <script src="js/cdn_jquery.dataTables.min.js"></script>
    

  </body>
</html>

<script>
    
    
    $().ready(function() {


          $('#tblStock').DataTable({
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
                order: [[1, 'asc']],
                ordering : false,
                bLengthChange: false,
                bFilter: false
            });


            // validate the comment form when it is submitted
            $("#formulario").validate({
                rules: {
                    id_producto_tipo: {
                        required: true,
                        
                    },
                    descripcion: {
                        required: true,
                        minlength: 3
                    },
                    stock: {
                      required: true,                      
                    },
                    codigo_producto: {
                      required: true,
                      minlength: 3
                    }
                   
                },
                messages: {                  
                    descripcion: {
                        required: "El campo producto es obligatorio",
                        minlength: "El campo producto debe tener al menos 3 caracteres"
                    },                    
                    stock: {
                      stock: "El Stock es obligatorio",                      
                    },
                    codigo_producto: {
                        required: "El campo código producto es obligatorio",
                        minlength: "El campo código producto debe tener al menos 3 caracteres"
                    }
                }
 
            });
        });


      function Editar(id_stock,stock_actual,id_sucursal)
      {
        $('#stock').val(stock_actual);
        $('#id_stock').val(id_stock);
        $('#id_sucursal').val(id_sucursal);        
        
        $('#modalStock').modal();         
      }

      function ActualizarStock()
      {
        
        
        try { 

                if($('#stock').val() =="")
                {
                  alert("Debe completar el stock");
                  $('#stock').focus();  
                  return;
                }

                if($('#stock').val() <= 0)
                {
                  alert("Debe ingresar un valor de cantidad mayor a cero");
                  $('#stock').focus();  
                  return;
                }             
                               
                parametros = $('#frmStock').serializeArray();		
                parametros.push({"name":"accion","value":"actualizar_stock"});
                parametros.push({"name":"id_producto","value": document.formulario.id_producto.value });
                

                $.ajax({ 

                      data:   parametros, 
                      encoding: "UTF-8",		
                      url:   "data/async.productos.php", 
                      type:  'post',  
                      success:  function (data) 
                      {                          

                        if(data.status == "OK")
                        {
                                               
                          $("#formulario").attr('action', 'productos_formulario.php'); 
                          $('#formulario').submit(); 
                          
                        }
                            
                        else
                          alert("Error desconocido");
                      },
                      error: function(xhr, desc, err){
                        alert("Error al agregar producto ");
                      } 
                  });
                }
                catch(err){
                alert(err);
                }

      }

</script>


<?php  
  $db = null; //saco de memoria el objeto
?>