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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Productos <small> / Listado de Productos</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="Nuevo();">
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
                  
                    
                  
                </div>
                <div class="panel-body">
                  
                      <div class="table-responsive" >
                          <table id="example" class="display" style="width:100%">
                          <thead>
                              <tr>                                  
                                  <th>Proveedor</th>
                                  <th>Código</th>                                
                                  <th>Producto</th>
                                  <th>Rubro</th>                                
                                  <th>C.Barra</th>                                
                                  <th>Precio</th>                                                            
                                  <th></th>                                              
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
    <div class="modal fade" id="modalProductos" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">    
  		<div class="modal-dialog" role="document">
        <div class="modal-content">
              <form id="frmProductos" action="remitos.php" method="post">                                                           
                    <input type="hidden" name="id_producto" id="id_producto"  value="" />
                    <input type="hidden" name="accion" id="accion"   value="" />
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Nuevo</h4>
                  </div>

                  <div class="modal-body">                        
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
                              echo "<option value='".$row['id_producto_tipo']."' ".$sel.">".$row['descripcion']."</option>";                                            
                          } 
                          $resultado = null;
                        
                        ?>                                                                         
                       </select>
                       </p>
                      <p>  
                        <label for="descripcion">Código Producto</label>   
                        <input type="text" name="codigo_producto" id="codigo_producto"  class="form-control" placeholder="" value="">
                      </p>
                      <p>  
                        <label for="descripcion">Código Barra</label>   
                        <input type="text" name="codigo_barra" id="codigo_barra"   class="form-control" placeholder="" value="">
                      </p>
                      <p>  
                        <label for="descripcion">Producto</label>   
                        <input type="text" name="descripcion" id="descripcion"  class="form-control" placeholder="Ingrese producto" value="">
                      </p>                      
                      <p>
                          <label for="precio">Precio</label>
                                  <input type="number" name="precio" id="precio" class="form-control" value="">
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
                  </div>              

                  <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="button" onClick="btnAceptar();" class="btn btn-primary">Guardar Cambios</button>
                  </div>
              </form>                                     
        </div>
  	  </div>
   </div>

  <!--MODAL DE STOCK-->
   <div class="modal fade" id="modalStock" tabindex="-1" role="dialog"  aria-hidden="true">
    <div class="modal-dialog  modal-xl">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h5 class="modal-title" id="ModalLabelStock">Stock de todas las sucursales</h5>
        </div>
        <div class="modal-body">
          
              <div class="table-responsive" >
                      <table id="datatableStock" class="display" style="width:100%">
                          <thead>
                              <tr>
                                  <th>Sucursal</th>                                
                                  <th>Stock</th>                                  
                                  <th></th>                                              
                              </tr>
                          </thead>           
                      </table>                      
            </div>
        </div>
        
        

      </div>
    </div>
  </div>
        

  <!-- MODAL STOCK EDITAR-->
  <div class="modal fade" id="modalStockEditar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">    
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
                            <p>                                                
                              <label>Producto</label>
                              <input type="text" name="producto_descripcion" id="producto_descripcion"  class="form-control"  value="" readonly>
                            </p>
                            <p>                                
                              <label>Sucursal</label>
                              <input type="text" name="sucursal_descripcion" id="sucursal_descripcion"  class="form-control"  value="" readonly>
                            </p>
                            <p>  
                              <label>Ingrese Stock</label>
                              <input type="number" name="stock" id="stock"  class="form-control" >       
                            </p>
                          
                      </div>              

                      <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" onClick="ActualizarStock();" class="btn btn-primary">Guardar Cambios</button>
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
       var mensaje = "<?php echo $mensaje;?>";  
       if(mensaje.length>0)
       {
          alert(mensaje);
       }
      




       $('#example thead tr')
        .clone(true)
        .addClass('filters')
        .appendTo('#example thead');
        
        

    $('#example').dataTable( {
        "ajax": {
          "url": "productos.data.php?id=0", //trae por ajax los datos
          "dataSrc": "data" //selecciona el dataset
        },
        "columns": [ //define las culumnas a mostrar del dataset,las mismas cantidad de celdas de la tabla html, tiene que coincidir con estas columnasm,si no no muestra nada           
          { "data": "proveedor" },
          { "data": "codigo_producto" },
          { "data": "producto" },
          { "data": "tipo" },
          { "data": "codigo_barra" },
          { "data": "precio" },          
          { "data": null,
            render: function ( data, type, row ) {
              
                    var buttons =   "<button id='e" + data.id_producto + "' type='button' title='Editar' class='btn btn-default btn-sm'><i class='glyphicon glyphicon glyphicon-edit'></i></button> <button id='b" + data.id_producto + "' type='button' title='Eliminar' class='btn btn-danger btn-sm'><i class='glyphicon glyphicon-remove'></i></button> <button id='s" + data.id_producto + "' type='button' title='Definir Stock' class='btn btn-warning btn-sm'><i class='glyphicon glyphicon-cog'></i></button>";

                    return buttons;
            }},                                                
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
        initComplete: function () {

          
            var api = this.api();
 
            // For each column
            api
                .columns()
                .eq(0)
                .each(function (colIdx) {
                    // Set the header cell to contain the input element
                    var cell = $('.filters th').eq(
                        $(api.column(colIdx).header()).index()
                    );

                    var title = $(cell).text();
                    
                    if(title!="")
                      $(cell).html('<input type="text" class="text-center" style="width:100%" placeholder="' + title + '" />');
 
                    // On every keypress in this input
                        $(
                            'input',
                            $('.filters th').eq($(api.column(colIdx).header()).index())
                        )
                        .off('keyup change')
                        .on('keyup change', function (e) {
                            e.stopPropagation();
 
                            // Get the search value
                            $(this).attr('title', $(this).val());
                            var regexr = '({search})'; //$(this).parents('th').find('select').val();
 
                            var cursorPosition = this.selectionStart;
                            // Search the column for that value
                            api
                                .column(colIdx)
                                .search(
                                    this.value != ''
                                        ? regexr.replace('{search}', '(((' + this.value + ')))')
                                        : '',
                                    this.value != '',
                                    this.value == ''
                                )
                                .draw();
                                  
                            $(this)
                                .focus()[0]
                                .setSelectionRange(cursorPosition, cursorPosition);
                        });
                });


                $('#example_filter').hide();
                
                
        },
      
      });
        
         
      // ELIMINAR
      $('#example').on('click', 'button.btn.btn-danger.btn-sm', function (e) { 
          e.preventDefault(); 

          $tr = $(this).closest('tr'); 
          var data = $('#example').DataTable().row($tr).data();
          

          if(confirm("¿Seguro que desea eliminar el producto " + data.producto + " ?"))
          {
                try {         
                  
                      $("#accion").val("eliminar");
                      $("#id_producto").val(data.id_producto); 
                      

                      var params = toJson('#frmProductos');
        
                    $.ajax({
                      type: "POST",
                      url: 'productos.data.php',
                      data: params,
                      contentType: "application/json; charset=utf-8",
                      crossDomain: true,
                      dataType: "json",
                        success: function (data, status, jqXHR) {                        
                              refreshGrilla();    
                              alert("Producto Eliminado con exito!"); 
                                
                        },
                        error: function(data){                      
                              alert(data.responseText);
                          }
                    });
                    
                }
                catch(err){
                    alert(err);
                } 
          }
          
      });

      // EDITAR
      $('#example').on('click', 'button.btn.btn-default.btn-sm', function (e) { 
          e.preventDefault(); 

          $tr = $(this).closest('tr'); 
          var data = $('#example').DataTable().row($tr).data();
          
          $('#myModalLabel').text("Modificar Producto");
          $("#accion").val("modificar");
          $("#id_producto").val(data.id_producto); 
          $("#id_producto_tipo").val(data.id_producto_tipo).change();
          $("#codigo_producto").val(data.codigo_producto); 
          $("#codigo_barra").val(data.codigo_barra); 
          $("#descripcion").val(data.producto); 
          $("#precio").val(data.precio);                     
          $("#id_proveedor").val(data.id_proveedor).change();
          $('#modalProductos').modal(); 
      });


      // VER STOCK
      $('#example').on('click', 'button.btn.btn-warning.btn-sm', function (e) { 
          e.preventDefault(); 

          $tr = $(this).closest('tr'); 
          var data = $('#example').DataTable().row($tr).data();
                    
          $("#accion").val("ver_stock");
          $("#id_producto").val(data.id_producto); 
          
          $("#ModalLabelStock").html(data.producto);    
          setTimeout(function(){$('#datatableStock').DataTable().ajax.reload(null, false);}, 10);

          $('#modalStock').modal(); 
      });

        //////////////////////////////////////////////////////////////////////////////////////////////STOCK GRID
        $('#datatableStock').dataTable( {        
        ajax: {
                url: "productos.data.stock.php",
                "data": function ( d ) {
                    d.id_producto = $('#id_producto').val()==""?0:$('#id_producto').val();                    
                    d.t = new Date().getTime();
                },
                dataType : "json",
                type: "GET"
        },
        "columns": [ 
          { "data": "sucursal" },
          { "data": "stock" },                  
          { "data": null,
            render: function ( data, type, row ) {
              
                    var buttons =   "<button id='e" + data.id_stock + "' type='button' title='Editar' class='btn btn-default btn-sm'><i class='glyphicon glyphicon glyphicon-edit'></i></button>";

                    return buttons;
            }},                                                
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
        initComplete: function () {                              
                $('#datatableStock_filter').hide();                
            },                            
      });


      // EDITAR SOTCK
      $('#datatableStock').on('click', 'button.btn.btn-default.btn-sm', function (e) { 
          e.preventDefault(); 

          $tr = $(this).closest('tr'); 
          var data = $('#datatableStock').DataTable().row($tr).data();
          
         
          $('#stock').val(data.stock);
          $('#id_stock').val(data.id_stock);
          $('#id_sucursal').val(data.id_sucursal);
          
          $('#producto_descripcion').val(data.producto);
          $('#sucursal_descripcion').val(data.sucursal);
          
          
          $('#modalStockEditar').modal();  

          $('#stock').focus();
          
          
          
      });



    }); //fin document ready

    
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
              parametros.push({"name":"id_producto","value": $("#id_producto").val() });
              

              $.ajax({ 

                    data:   parametros, 
                    encoding: "UTF-8",		
                    url:   "data/async.productos.php", 
                    type:  'post',  
                    success:  function (data) 
                    {                          

                      if(data.status == "OK")
                      {
                        //refresh
                        setTimeout(function(){$('#datatableStock').DataTable().ajax.reload(null, false);}, 100);
                        $('#modalStockEditar').modal('hide');
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

    function Nuevo()
    { 
        $('#myModalLabel').text("Nuevo Producto");
        $("#id_producto").val("0"); 
        $("#accion").val("nuevo"); 
        $("#id_producto_tipo").val(0).change();
        $("#codigo_producto").val(""); 
        $("#codigo_barra").val(""); 
        $("#descripcion").val(""); 
        $("#precio").val("");                     
        $("#id_proveedor").val(0).change();
        $('#modalProductos').modal();
    }

    function btnAceptar()
    {
      
      if($("#id_producto_tipo").val()==0)
      {
        alert("Debe seleccionar Rubro");
        $("#id_producto_tipo").focus();
        return;
      }

      if($("#codigo_producto").val()=="")
      {
        alert("Debe ingresar código de producto");
        $("#codigo_producto").focus();
        return;
      }

                
      if($("#descripcion").val()=="")
      {
        alert("Debe ingresar la descripción del producto");
        $("#descripcion").focus();
        return;
      }

      if($("#descripcion").val()=="")
      {
        alert("Debe ingresar la descripción del producto");
        $("#descripcion").focus();
        return;
      }
       
      if($("#precio").val()=="")
      {
        alert("Debe ingresar precio");
        $("#precio").focus();
        return;
      }

      if($("#id_proveedor").val()==0)
      {
        alert("Debe seleccionar Proveedor");
        $("#id_proveedor").focus();
        return;
      }
       


        try { 
                           
              var params = toJson('#frmProductos');
 
             $.ajax({
                 type: "POST",
                 url: 'productos.data.php',
                 data: params,
                 contentType: "application/json; charset=utf-8",
                 crossDomain: true,
                 dataType: "json",
                 success: function (data, status, jqXHR) {
                     
                       refreshGrilla();

                        if($("#id_producto").val()==0)
                          alert("Producto Agregado con exito!"); 
                        else                        
                          alert("Producto Modificado con exito!");                         

                       $('#modalProductos').modal('hide');
                 },
                 error: function(data){                      
                      alert(data.responseText);
                  }
             });
             
         }
         catch(err){
             alert(err);
         } 

    }

    function refreshGrilla()
    {
      setTimeout(function(){$('#example').DataTable().ajax.reload(null, false);}, 100);
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
    

</script>

<?php
  $db = null; //saco de memoria el objeto
?>