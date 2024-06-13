<?php
	$current_section = "remitos";
	require('layout.constantes.php');
	require('layout.app.php'); 
  require_once('data/class.database.php');
	
  $db = new Database(); //para todas la conexiones de esta pagina
  $id_nuevo_responsable = 0;
  $mensaje = "";
  $fecha = date('Y-m-d');

  
	if(isset($_REQUEST["accion"]))
  {
  
    try
			{

        $accion = $_REQUEST["accion"];        
                
        switch($accion)
        {
          case "agregar_nuevo_responsable":
                $descripcion = $_REQUEST["nuevo_responsable"];
                $sql = "insert into responsables (descripcion) values ('$descripcion')";
              	$db->query($sql);
                $db->execute();

                $id_nuevo_responsable = $db->lastInsertId();
                $mensaje ="El nuevo responsable se agrego con exito";

                break;
               
        }
        
			
				
			}
      catch(Exception $e)
			{
				$mensaje = $e->getMessage();
			}
			

    
  }

	 
 //session_destroy();	
	
?>
<!DOCTYPE html>
<html lang="es">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
	<meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title><?php echo TITULO;?> | Remitos</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
	  <link href="css/bootstrap-toggle.min.css" rel="stylesheet">    
    <link href="css/select2.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css" rel="stylesheet">   
    <link href="https://cdn.jsdelivr.net/npm/bs-stepper/dist/css/bs-stepper.min.css" rel="stylesheet">           
  </head>

  <body onload="ResfrecarGrilla();">
	
    
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
            <h4><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Remitos <small> / Nuevo Remito</small></h4>
          </div>
          <div class="col-md-2">          
                <button class="btn btn-default" id="btnNuevaAlta" onClick="AgregarNuevoRemito();" type="button">
                	    Generar Remito     
                </button>
            
              
          </div>
        </div>
      </div>
    </header>
	
   

    <section id="main">
      <div class="container-fluid">

          <div class="col-md-2  hidden-xs hidden-sm">
            <div class="list-group">
              <?php Layout::CreateMenuIzquierdo($current_section);?>
            </div>
 
          </div>
                               
          <!---->
          
          <div class="col-md-10">
            <div class="card card-default">
              <div class="card-header">
                <h3 class="card-title">bs-stepper</h3>
              </div>
              <div class="card-body p-0">
                <div class="bs-stepper">
                  <div class="bs-stepper-header" role="tablist">
                    <!-- your steps here -->
                    <div class="step" data-target="#logins-part">
                      <button type="button" class="step-trigger" role="tab" aria-controls="logins-part" id="logins-part-trigger">
                        <span class="bs-stepper-circle">1</span>
                        <span class="bs-stepper-label">Logins</span>
                      </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#information-part">
                      <button type="button" class="step-trigger" role="tab" aria-controls="information-part" id="information-part-trigger">
                        <span class="bs-stepper-circle">2</span>
                        <span class="bs-stepper-label">Various information</span>
                      </button>
                    </div>
                  </div>
                  <div class="bs-stepper-content">
                    <!-- your steps content here -->
                    <div id="logins-part" class="content" role="tabpanel" aria-labelledby="logins-part-trigger">
                      <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
                      </div>
                      <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                      </div>
                      <button class="btn btn-primary" onclick="stepper.next()">Next</button>
                    </div>
                    <div id="information-part" class="content" role="tabpanel" aria-labelledby="information-part-trigger">
                      <div class="form-group">
                        <label for="exampleInputFile">File input</label>
                        <div class="input-group">
                          <div class="custom-file">
                            <input type="file" class="custom-file-input" id="exampleInputFile">
                            <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                          </div>
                          <div class="input-group-append">
                            <span class="input-group-text">Upload</span>
                          </div>
                        </div>
                      </div>
                      <button class="btn btn-primary" onclick="stepper.previous()">Previous</button>
                      <button type="submit" class="btn btn-primary">Submit</button>
                    </div>
                  </div>
                </div>
              </div>
              <!-- /.card-body -->
              <div class="card-footer">
                Visit <a href="https://github.com/Johann-S/bs-stepper/#how-to-use-it">bs-stepper documentation</a> for more examples and information about the plugin.
              </div>
            </div>
            <!-- /.card -->
          </div>
        

          <!---->
          <div class="col-md-10">
            <!-- Website Overview -->

            <div class="panel panel-default">
                          
              <div class="panel-body">

              <!---->
					    <ul class="nav nav-tabs" role="tablist">
                <li class="active">
                  <a href="#principal" role="tab" data-toggle="tab">Principal</a>
                </li>
                <li>
                  <a href="#detalle" role="tab" data-toggle="tab">Detalle</a>
                </li>
              </ul>

				<!-- Tab panes -->
				<div class="tab-content">
				  <div class="tab-pane active" id="principal">
            <form id="frmNuevoRemito" action="remitos.php" method="post">
                  <input type="hidden" name="accion" id="accion"   value="nuevo_remito">
                  <div class="form-row">
                        <div class="form-group col-md-2">
                          <label>Fecha</label>
                          <input type="date" class="form-control" id="fecha" value="<?php echo $fecha;?>" name="fecha">
                        </div>
                        <div class="form-group col-md-6">
                          <label>Destino</label>
                          <input type="text" class="form-control" id="destino" name="destino">
                        </div>
                        <div class="form-group col-md-4">
                          <label>Nro remito</label>
                          <input type="text" class="form-control" id="remito_preimpreso" name="remito_preimpreso">
                        </div>                  
                </div>
                                
                <div class="col-md-12 mb-12">
                    <div class="input-group">
                      <label for="validationServer01">Responsable</label>
                      
                        <select class="form-control cbo-responsables" name="id_responsable" id="id_responsable">
                        <?php 
                          $sql = 'SELECT * from responsables';
                          $db->query($sql);
                      
                          $resultado = $db->resultset();

                          if($id_nuevo_responsable==0)
                            echo "<option value='0' selected> << Seleccione Responsable >> </option>";
                          else
                            echo "<option value='0'> << Seleccione Responsable >> </option>";

                          foreach($resultado as $row) 
                          {
                              $sel = ($id_nuevo_responsable == $row['id_responsable']) ? " selected" : "";
                              echo "<option value='".$row['id_responsable']."' ".$sel.">".$row['descripcion']."</option>";                                            
                          }        
                        
                        ?>                                                                         
                      </select>     

                      <span class="input-group-btn">                                     
                        <button class="btn btn-primary" style="margin-top: 25px!important;" type="button" onClick="$('#addNewResponsable').modal();">Nuevo</button>
                      </span>
                    </div>
                </div>


                <div class="form-group col-md-12">
                  <label >Observaciones</label>
                  <textarea class="form-control"  rows="3" name="observaciones"></textarea>
                </div>
                
                

              </form>
                                                          
				    </div>
            <div class="tab-pane" id="detalle">
                      <!----GRILLLLLLLLAAAA----->
                      
                      <form name="frmAgregarProducto" id="frmAgregarProducto" method="post">
                            
                                   
                          <div class="form-group col-md-12">
                                <div class="table-responsive">
                                      <table class="table table-striped text-nowrap" id="datatable" >
                                        <thead>        
                                          <th class="text-center">Cantidad</th>
                                          <th class="text-center">Descripcion</th>
                                          <th class="text-center">Precio</th>
                                          <th class="text-center">Subtotal</th>
                                          <th class="text-center">% Desc</th>
                                          <th class="text-center">Total</th>
                                          <th class="text-center"></th>
                                        </thead>                        
                                      </table>
                                </div>
                          </div>
                          
                          <div class="form-row">
                            <div class="col col-md-1 form-group">
                                <label>Código</label>
                                <input type="number" class="form-control" id="codigo" name="codigo">
                            </div>
                            <div class="col col-md-3 form-group">
                                <label>Producto</label>
                                <select class="cbo-productos" name="producto" id="producto" style="width: 100%!important;" >
                                      <?php 
                                        $sql = 'SELECT p.id_producto, 
                                                CONCAT(p.descripcion, " (", pt.descripcion, ")") AS producto 
                                                FROM productos p inner join productos_tipos pt 
                                                on p.id_producto_tipo = pt.id_producto_tipo
                                                order by p.descripcion ';
                                        $db->query($sql);
                                    
                                        $resultado = $db->resultset();
                                        
                                        echo "<option value='0' selected> << Seleccione producto >> </option>";
                                        foreach($resultado as $row) 
                                        {
                                            echo "<option value=".$row['id_producto'].">".$row['producto']."</option>";                                            
                                        }        
                                      
                                      ?>                                                                         
                                  </select>
                            </div>
                            <div class="col col-md-1 form-group">
                                <label>Cantidad</label>
                                <input type="number" class="form-control" id="cantidad" name="cantidad">
                            </div>
                            <div class="col col-md-1  form-group">
                                <label>Precio</label>
                                <input type="number" class="form-control" id="precio" name="precio">
                            </div>
                            <div class="col col-md-1 form-group">
                                <label>Subtotal</label>
                                <input type="number" class="form-control" id="subtotal" name="subtotal" readonly="true">
                            </div>
                            <div class="col col-md-1 form-group">
                                <label>% Dec.</label>
                                <input type="number" class="form-control" id="descuento" name="descuento">
                            </div>
                            <div class="col col-md-1 form-group">
                                <label>Total</label>
                                <input type="number" class="form-control" id="total" name="total">
                            </div>
                            <div class="col col-md-1 form-group">
                                <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                <button class="btn btn-primary form-control" id="btnAgregar"  type="button" onClick="AgregarProducto();">Agregar</button>
                            </div>
                            
                          </div>
                                                                                                        

                        </form>
                          <!------------GRILLAAAA--->
                         
                      
                                
            </div>
				</div>	
          <!-- fin Tab panes -->             
                                        
                    


              </div><!--body-->
            </div> <!--panel-->     



                                                         

               

          </div><!--md-10-12-->

        

      </div> <!--container-fluid-->
    </section>


    
    <div class="modal fade" id="addNewResponsable" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">    
  		<div class="modal-dialog" role="document">
    	<div class="modal-content">
            <form id="frmNuevoResponsable" action="remitos.php" method="post">                                       
                <input type="hidden" name="accion" id="accion"   value="agregar_nuevo_responsable">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="myModalLabel">Agregar Nuevo Responsable</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                      <label>Descripcion</label>
                      <input type="text" name="nuevo_responsable" id="nuevo_responsable"  class="form-control" >
                    </div>                              			          
                </div>              

                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                  <button type="button" onClick="AgregarNuevoResponsable();" class="btn btn-primary">Guardar Cambios</button>
                </div>
            </form>                                     
    	</div>
  	</div>
   </div>
        

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
	  <script src="js/bootstrap-toggle.min.js"></script>
    <script src="js/cdn_jquery.dataTables.min.js"></script>                                         
    <script src="js/ajax_select2.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bs-stepper/dist/js/bs-stepper.min.js"></script>
    		
    

    <script type="text/javascript">

      var _target = 'data/async.remitos.php';
      var _img_loading = '<img src="img/loader.gif" />';

			$(document).ready(function() {

            var mensaje = "<?php echo $mensaje;?>";  
            if(mensaje.length>0)
            {
                alert(mensaje);
            }
            
				    var $objcboproductos = $(".cbo-productos");
            var $objcboresponsables = $(".cbo-responsables");

            $objcboresponsables.select2();
            $objcboproductos.select2();                        

            
            var buttons  = '<button type="button" title="Editar" class="btn btn-default btn-sm">Editar</button>&nbsp;&nbsp;&nbsp;&nbsp;';
                buttons += '<button type="button" title="Eliminar" class="btn btn-danger btn-sm">Eliminar</button>';
                

            var tableDetail = $('#datatable').DataTable({
                    "language": { // le seteo el idioma, de la tabla, despues vemos de levantarlo de un archivo externo
                      "lengthMenu": "Mostrar _MENU_ filas por página",
                      "zeroRecords": "Sin resultados",
                      "info": "Mostrando página _PAGE_ de _PAGES_",
                      "print": "Imprimir",
                      "infoEmpty": "Sin resultados",
                      "infoFiltered": "(Filtrando _MAX_ totales)",
                      "search": "Buscar",
                      "processing": '<i class="fa fa-spinner fa-spin fa-2x fa-fw"></i><span >Cargando...</span>',
                      "oPaginate": {
                        "sFirst": "Primera página", 
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente",
                        "sLast": "Última página" 
                      }
                    },                  
                    processing: true,
                    serverSide: false,
                    pageLength: 5,
                    scrollY: "200px",
                    ajax: {
                            url: _target,
                            "data": function ( d ) {        
                                d.accion = "listar_productos";          
                                d.t = new Date().getTime();                    
                            },
                            dataType : "json",
                            type: "GET"
                    },
                    "columns": [  
                        { "data": "cantidad"},
                        { "data": "tipo"},
                        { "data": "descripcion" },
                        { "data": "cantidad"},
                        { "data": "cantidad"},
                        { "data": "cantidad"},
                        {   
                            data: null,
                            className: "center",
                            defaultContent: buttons
                        }                                                                                                                  
                    ],
                    ordering : false,
                    bLengthChange: false,
                    bFilter: false
              }); 


              
              $('#datatable').on('click', 'button.btn.btn-danger.btn-sm', function (e) 
              {
                  e.preventDefault();
                  $tr = $(this).closest('tr')
                  var data = $('#datatable').DataTable().row($tr).data(); 
                  try { 
                                   
                        var parametros = [];
                            parametros.push({"name":"accion","value":"eliminar_producto_en_remito"});
                            parametros.push({"name":"producto","value": data.id_producto });
                        $.ajax({ 
                      
                              data:   parametros, 
                              encoding: "UTF-8",		
                              url:   _target, 
                              type:  'post',
                              async: false,  //OJO ES SINCRONICO
                              success:  function (data) 
                              {                                                       
                                  existe = data.borrado;
                                  $('#datatable').DataTable().row($tr).remove().draw();
                                  //ResfrecarGrilla();
                              },
                              error: function(xhr, desc, err){
                                alert("Error al agregar producto ");
                              } 
                          });
                    }
                    catch(err){
                        alert(err);
                    }

              }); 

              $('#datatable').on('click', 'button.btn.btn-default.btn-sm', function (e) 
              {
                  e.preventDefault();
                  $tr = $(this).closest('tr')
                  var data = $('#datatable').DataTable().row($tr).data(); 
                  try { 
                         
                    
                            $('#cantidad').val(data.cantidad);                                                                            
                            $('#producto').val(data.id_producto).trigger('change');
                            $('#cantidad').focus();

                        var parametros = [];
                            parametros.push({"name":"accion","value":"eliminar_producto_en_remito"});
                            parametros.push({"name":"producto","value": data.id_producto });
                        $.ajax({ 
                      
                              data:   parametros, 
                              encoding: "UTF-8",		
                              url:   _target, 
                              type:  'post',
                              async: false,  //OJO ES SINCRONICO
                              success:  function (data) 
                              {                                                       
                                  existe = data.borrado;
                                  $('#datatable').DataTable().row($tr).remove().draw();
                                  //ResfrecarGrilla();
                              },
                              error: function(xhr, desc, err){
                                alert("Error al agregar producto ");
                              } 
                          });
                    }
                    catch(err){
                        alert(err);
                    }

              });
              
              //al presionar cantidad foco al boton agregar
              $("#cantidad").on('keyup', function (e) {
                  if (e.key === 'Enter' || e.keyCode === 13) 
                  {
                    $('#btnAgregar').focus();
                  }
              });


			});

        function ListarProductosRemitos()
        {

            var $deg = $('div#GrillaProductosCargados').html(_img_loading); 

            var parametros = [];
                parametros.push({"name":"accion","value":"listar_productos"});

              $.ajax({ 
          
                  data:  parametros,  
                  url:   _target, 
                  type:  'post',  
                  success:  function (response) 
                      { 
                        $deg.html(response);
                       
                      }
              });
              
              
        }

        function AgregarProducto()
        {

          try { 

                  

                  if($('#cantidad').val() =="")
                  {
                    alert("Debe completar la cantidad");
                    $('#cantidad').focus();  
                    return;
                  }

                  if($('#cantidad').val() <= 0)
                  {
                    alert("Debe ingresar un valor de cantidad mayor a cero");
                    $('#cantidad').focus();  
                    return;
                  }

                  if($('#producto').val() =="0")
                  {
                    alert("Debe Seleccionar un producto");
                    $('#producto').focus();  
                    return;
                  }


                  

                  let result =  VerificoSiExisteProductoCargado();

                  if(result)
                  {
                    alert("Este prducto ya se encuentra cargado");
                    $('#producto').focus();  
                    return;
                  }
                  

                  parametros = $('#frmAgregarProducto').serializeArray();		
                  parametros.push({"name":"accion","value":"agregar_producto"});
                  $.ajax({ 
                
                        data:   parametros, 
                        encoding: "UTF-8",		
                        url:   _target, 
                        type:  'post',  
                        success:  function (data) 
                        {                           
                          if(data.status == "OK")
                          {
                            $('#cantidad').val("");                                                                            
                            $('#producto').val('0').trigger('change');
                            $('#producto').select2('open');
                            
                            ResfrecarGrilla();

                            
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


        function VerificoSiExisteProductoCargado()
        {
            var existe = false;

          try { 
                                   

                  parametros = $('#frmAgregarProducto').serializeArray();		
                  parametros.push({"name":"accion","value":"existe_producto_en_remito"});
                  $.ajax({ 
                
                        data:   parametros, 
                        encoding: "UTF-8",		
                        url:   _target, 
                        type:  'post',
                        async: false,  //OJO ES SINCRONICO
                        success:  function (data) 
                        {                                                       
                            existe = data.existe;
                        },
                        error: function(xhr, desc, err){
                          alert("Error al agregar producto ");
                        } 
                    });
              }
              catch(err){
                  alert(err);
              }

              return existe ;
        }


        function ResfrecarGrilla()
        {
          setTimeout(function(){$('#datatable').DataTable().ajax.reload(null, false);}, 10);
        }

       
        function AgregarNuevoResponsable()
        {
            if($('#nuevo_responsable').val() =="")
            {
              alert("Debe Ingresar la descripción del nuevo responsable");
              $('#nuevo_responsable').focus();  
              return;
            }

            $('#frmNuevoResponsable').submit();
            
        }

        function AgregarNuevoRemito()
        {

            
            let ID_REMITO_FIELD = "<?php echo $_SESSION['ID_REMITO_FIELD'];?>";
            if($('#fecha').val() =="")
            {
              alert("Debe Ingresar Fecha de remito");
              $('#fecha').focus();  
              return;
            }

            if($('#destino').val() =="")
            {
              alert("Debe Ingresar Destino");
              $('#destino').focus();  
              return;
            }


            if($('#id_responsable').val() =="0")
            {
              alert("Debe Ingresar un responsable");
              $('#destino').focus();  
              return;
            }

            if(ID_REMITO_FIELD=='remito_preimpreso')
            {
              //SI USO EL REMITO EXTERNO ES OBLIGATORIO CARGARLO  
              if($('#remito_preimpreso').val() =="")
              {
                alert("Debe Ingresar en nro remito");
                $('#remito_preimpreso').focus();  
                return;
              }
            }
            

            var table = $('#datatable').DataTable();
            if( table.data().count() == 0)
            {

              alert("Debe Ingresar almenos 1 producto al remito");              
              return;
            }
          
            $('#frmNuevoRemito').submit(); 

        }

		</script>

  </body>
</html>

<?php
  $db = null; //saco de memoria el objeto
?>