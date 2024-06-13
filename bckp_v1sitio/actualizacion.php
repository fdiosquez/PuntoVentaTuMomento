<?php
	$current_section = "actualizacion";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');
  require_once('data/common.php');

  $mensaje = ""; //usados para las alertas en js
  $db = new Database(); //para todas la conexiones de esta pagina

  


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
    <link href="https://cdn.datatables.net/1.13.7/css/jquery.dataTables.min.css" rel="stylesheet">   
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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Actualización <small> / Actualización masiva de productos</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="$('#modalFiltros').modal();">
                Filtros     
               </button>
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="ActualizarPrecios();">
                Aplicar Porcentaje
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
                  
                    
                  
                </div>
                <div class="panel-body">
                  
                      <div class="table-responsive" >
                          <table id="example" class="display" style="width:100%">
                          <thead>
                              <tr>                                  
                                  <th>Proveedor</th>                                                                  
                                  <th>Rubro</th>
                                  <th>Producto</th>                                                                                  
                                  <th>Precio<BR>Actual</th>                                                            
                                  <th>Precio<BR>Calculado</th>                                                                          
                              </tr>
                          </thead>                       
                          </table>
                      </div>    


                </div>
            </div>

          </div>

        </div>
      </div>
    </section>
    
    

    <!--MODAL DE PRODUCTOS-->
    <div class="modal fade" id="modalFiltros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">    
  		<div class="modal-dialog" role="document">
        <div class="modal-content">
              <form id="frmFiltros" action="#" method="post">                                                           
                    <input type="hidden" name="id_producto" id="id_producto"  value="" />
                    <input type="hidden" name="accion" id="accion"   value="" />
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Filtros de busqueda</h4>
                  </div>

                  <div class="modal-body">
                      <p>
                          <label for="activo">Proveedor</label>
                          <select class="form-control" name="id_proveedor" id="id_proveedor">                                                                                                         
                          <?php 
                            $sql = 'SELECT * from proveedores';
                            $db->query($sql);
                        
                            $resultado = $db->resultset();

                            
                             echo "<option value='0' selected> << Seleccione Proveedor >> </option>";
                            
                            foreach($resultado as $row) 
                            {                                
                                echo "<option value='".$row['ID_PROVEEDOR']."' >".$row['DESCRIPCION']."</option>";                                            
                            } 
                            
                            $resultado = null;
                          
                          ?>
                          </select>                                  
                      </p>                          
                      <p>                                                
                      <label for="id_producto_tipo">Rubro producto</label> 
                      <select class="form-control" name="id_producto_tipo" id="id_producto_tipo">
                        <?php 
                          $sql = 'SELECT * from productos_tipos';
                          $db->query($sql);
                          $resultado = $db->resultset();
                          echo "<option value='0'> << Seleccione Rubro >> </option>";
                          foreach($resultado as $row) 
                          {                            
                              echo "<option value='".$row['id_producto_tipo']."' >".$row['descripcion']."</option>";                                            
                          } 
                          $resultado = null;
                        
                        ?>                                                                         
                       </select>
                      </p>                                           
                      <p>  
                        <label for="descripcion">Producto</label>   
                        <input type="text" name="descripcion" id="descripcion"  class="form-control" placeholder="" value="">
                      </p>                      
                      <p>
                          <label for="porcentaje">Porcentaje</label>
                          <input type="number" name="porcentaje" id="porcentaje" class="form-control" value="">
                      </p>                          
                                                                        			          
                  </div>              

                  <div class="modal-footer">                    
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="button" onClick="btnAceptar();" class="btn btn-primary">Calcular</button>
                  </div>
              </form>                                     
        </div>
  	  </div>
   </div>

  
               
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.7/js/jquery.dataTables.min.js"></script>
    <script src="js/bootstrap.min.js"></script>    

  </body>
</html>

<script>
    $(document).ready(function() 
    {        	
            

    $('#example').dataTable( {
        ajax: {
                url: "actualizacion.data.php",
                "data": function ( d ) {
                    d.id_proveedor = $("#id_proveedor").val();                  
                    d.id_producto_tipo = $("#id_producto_tipo").val();
                    d.descripcion = $("#descripcion").val();
                    d.porcentaje = $("#porcentaje").val();
                    d.t = new Date().getTime();
                },
                dataType : "json",
                type: "GET"
        },
        "columns": [ //define las culumnas a mostrar del dataset,las mismas cantidad de celdas de la tabla html, tiene que coincidir con estas columnasm,si no no muestra nada           
          { "data": "proveedor" },          
          { "data": "tipo" },
          { "data": "producto" },                    
          { "data": "precio" },          
          { "data": "precio_calculado" },                                                        
        ],     
        "language": { // le seteo el idioma, de la tabla, despues vemos de levantarlo de un archivo externo
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
        ordering : false,
        bLengthChange: false,
        bFilter: false
      
      });

                       



    }); //fin document ready

     

    
    function btnAceptar()
    {
      
      if(validar())return;

      refreshGrilla();
      $('#modalFiltros').modal('hide');

    }

    function refreshGrilla()
    {
      setTimeout(function(){$('#example').DataTable().ajax.reload(null, false);}, 100);
    }

    function validar()
    {
      if($("#id_proveedor").val()==0 && $("#id_producto_tipo").val()==0 && $("#descripcion").val()=="")
      {
        alert("Debe seleccionar ó completar almenos un dato para calcular");        
        return true;
      }
      
      if($("#porcentaje").val()=="")  
      {
        alert("El porcentaje es obligatorio!");        
        $("#porcentaje").focus();
        return true;
      }

    }

    function toJson(form)
    {   
        try { 
            var loginForm = $(form).serializeArray();
            var loginFormObject = {};
            $.each(loginForm,
                function(i, v) {
                    loginFormObject[v.name] = v.value;
                });
            return  JSON.stringify(loginFormObject);   
        }
        catch(err){
            alert(err);
        } 
    }


    function ActualizarPrecios()
    {
      
      if(validar())
          return;

      if(!confirm("Seguro que desea aplicar un " + $("#porcentaje").val() + "% a los productos seleccionados?"))
      {
        return;            
      }

      var table = $('#example').DataTable(); 
      var data = table.rows().data();          
      
      
      id_productos = [];      
      for(j=0;j<data.length;j++)
      {
        id_productos.push(data[j].id_producto);
      }

      let IDs = id_productos.join(",");


      try { 
              
              var params = {};
                  params["accion"] = "actualizar_stock";
                  params["id_productos"] = IDs;
                  params["porcentaje"] = $("#porcentaje").val();                                                                                                       

              $.ajax({ 
                    data:   JSON.stringify(params), 
                    encoding: "UTF-8",		
                    url:   "actualizacion.data.php", 
                    type:  'POST',
                    contentType: "application/json; charset=utf-8",
                    crossDomain: true,
                    dataType: "json",  
                    success:  function (data) 
                    {                          

                      
                      if(data.status == "OK")
                      {
                        

                        $("#id_proveedor").val(0).change();
                        $("#id_id_producto_tipo").val(0).change();
                        $("#porcentaje").val(""); 
                        $("#descripcion").val(""); 
                        
                        alert('cambios realizados con exito');

                        setTimeout(function(){$('#example').DataTable().ajax.reload(null, false);}, 100);
                      }                                   
                      else
                        alert("Error desconocido al intentar actualizar precios");
                    },
                    error: function(xhr, desc, err){
                      alert("Error al intentar actualizar precios");
                    } 
                });

        }catch(err){
          alert(err);
        }

    }
    

</script>

<?php
  $db = null; //saco de memoria el objeto
?>