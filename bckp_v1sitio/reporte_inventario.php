<?php
	$current_section = "reporte";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $mensaje = ""; //usados para las alertas en js
  $db = new Database(); 
  
  

  $fecha_desde = isset($_REQUEST["fecha_desde"]) ? $_REQUEST["fecha_desde"] : "";
  $fecha_hasta =  isset($_REQUEST["fecha_hasta"]) ? $_REQUEST["fecha_hasta"] : "";
  $id_producto_tipo =  isset($_REQUEST["id_producto_tipo"]) ? $_REQUEST["id_producto_tipo"] : "0";
  $id_responsable = isset($_REQUEST["id_responsable"]) ? $_REQUEST["id_responsable"] : "0";
  $id_remito = isset($_REQUEST["id_remito"]) ? $_REQUEST["id_remito"] : "";
  $tipo_descripcion = isset($_REQUEST["tipo_descripcion"]) ? $_REQUEST["tipo_descripcion"] : "";
  $resp_descripcion = isset($_REQUEST["resp_descripcion"]) ? $_REQUEST["resp_descripcion"] : "";
  

  if($fecha_desde=="")
    $fecha_desde = date('Y-m-d');

  if($fecha_hasta=="")
    $fecha_hasta = date('Y-m-d');

  $filtro_texto = "FILTROS: ";

  

  $filtro_texto .= "Fecha desde ".date("d/m/Y", strtotime($fecha_desde))." hasta ".date("d/m/Y", strtotime($fecha_hasta));

  if(strlen($id_remito)>0)
  {
    $filtro_texto .= " y Remito Nro = ".$id_remito;
  }

  if($id_producto_tipo!=0)
  {
    $filtro_texto .= " y Tipo = ".$tipo_descripcion;
  }

  if($id_responsable!=0)
  {
    $filtro_texto .= " y Responsable = ".$resp_descripcion;
  }
  
  
?>

                    
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><?php echo TITULO;?> | Reporte de inventario</title>
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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Reporte <small> / Reporte de inventario</small></h2>
          </div>
          <div class="col-md-2">
          
            <div class="dropdown create">
               <button class="btn btn-default" id="btnNuevaFabrica" type="button" onclick="$('#addFiltros').modal();">
                Filtros      
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
                <h3 class="panel-title"><?php echo $filtro_texto;?></h3>
              </div>
                <div class="panel-body">
                                                                                                       
                    <div class="table-responsive" >                      
                        <table id="example" class="display " style="width:100%">
                        <thead>
                            <tr>
                                <th>Remito</th>
                                <th>Fecha</th>                                                                                               
                                <th>Destino</th>
                                <th>Nombre y Apellido</th>                                
                                <th>Cantidad</th> 
                                <th>Tipo</th>
                                <th>Observaciones</th>               
                            </tr>
                        </thead>
                        <tbody>
                        <?php                              
			
                       
                          $sql = "SELECT  r.id_remito, 
                                  res.descripcion as responsable, 
                                  u.nombre_completo as creado, 
                                  r.fecha, 
                                  r.destino, 
                                  r.remito_preimpreso, 
                                  r.observaciones, 
                                  p.descripcion as producto, 
                                  pt.descripcion as tipo, 
                                  rd.cantidad 
                              FROM remitos as r inner join responsables as res 
                                      on r.id_responsable = res.id_responsable 
                                    inner join usuarios as u 
                                      on r.id_usuario = u.id_usuario 
                                    inner join remitos_detalle rd 
                                      on rd.id_remito = r.id_remito 
                                    inner join productos p 
                                      on rd.id_producto = p.id_producto 
                                    inner join productos_tipos pt 
                                      on pt.id_producto_tipo = p.id_producto_tipo 
                              WHERE 1 = 1";

                            $sql .= " and r.fecha between '$fecha_desde' and '$fecha_hasta'";

                            if(strlen($id_remito)>0) 
                            {
                              $sql .= " and r.".$_SESSION['ID_REMITO_FIELD']." = '$id_remito'";
                            }

                            if(strlen($id_producto_tipo)>0 && $id_producto_tipo != 0) 
                            {
                              $sql .= " and p.id_producto_tipo = $id_producto_tipo";
                            }

                            if(strlen($id_responsable)>0 && $id_responsable != 0) 
                            {
                              $sql .= " and r.id_responsable = $id_responsable";
                            }
                            
                                                                                   
                            $db->query($sql);
                                    
                            $resultado = $db->resultset();

                            foreach($resultado as $row) 
                            {
                                
                                echo "<tr>";
                                echo "<td>".$row[$_SESSION['ID_REMITO_FIELD']]."</td>";
                                echo "<td>".$row['fecha']."</td>";
                                echo "<td>".$row['destino']."</td>";
                                echo "<td>".$row['responsable']."</td>";
                                echo "<td>".$row['cantidad']."</td>";
                                echo "<td>".$row['tipo']."</td>";
                                echo "<td>".$row['observaciones']."</td>";
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
    
   
    <div class="modal fade" id="addFiltros" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  		<div class="modal-dialog" role="document">
    	<div class="modal-content">
      		<form id="FrmTipoFiltro" method="post" action="reporte_inventario.php">
              <input type="hidden" name="tipo_descripcion" id="tipo_descripcion"  value="" />                
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Filtros del reporte</h4>
              </div>
			  
              <div class="modal-body">
			  
			          <div class="form-group">
                  <label>Fecha Desde</label>
                  <input type="date" name="fecha_desde" id="fecha_desde" class="form-control" value="<?php echo $fecha_desde;?>"  >				
                </div>
				
                <div class="form-group">
                  <label>Fecha Hasta</label>
                  <input type="date" name="fecha_hasta" id="fecha_hasta" class="form-control" value="<?php echo $fecha_hasta;?>">
                </div>
				
                <div class="form-group">
                  <label>Tipo de producto</label>
                  <select class="form-control" name="id_producto_tipo" id="id_producto_tipo" >
                    <?php 
                      $sql = 'SELECT * FROM productos_tipos';
                      $db->query($sql);
                  
                      $resultado = $db->resultset();
                      
                      echo "<option value='0' selected> << Todos los tipos >> </option>";
                      foreach($resultado as $row) 
                      {
                          $sel = ($row['id_producto_tipo'] == $id_producto_tipo ) ? " selected" : "";
                          echo "<option value='".$row['id_producto_tipo']."' ".$sel.">".$row['descripcion']."</option>";                                            
                      }        
                    
                    ?>                                                                         
                  </select>  
                </div>
                <div class="form-group">
                  <label>Responsable</label>
                  <select class="form-control" name="id_responsable" id="id_responsable" >
                    <?php 
                      $sql = 'SELECT * FROM responsables';
                      $db->query($sql);
                  
                      $resultado = $db->resultset();
                      
                      echo "<option value='0' selected> << Todos los tipos >> </option>";
                      foreach($resultado as $row) 
                      {
                          $sel = ($row['id_responsable'] == $id_responsable ) ? " selected" : "";
                          echo "<option value='".$row['id_responsable']."' ".$sel.">".$row['descripcion']."</option>";                                            
                      }        
                    
                    ?>                                                                         
                  </select>  
                </div>
                <div class="form-group">
                  <label>Nro Remito</label>
                  <input type="number" name="id_remito" class="form-control" >
                </div>

              </div>
              <div class="modal-footer">
                <button type="button" id="btnCerrar" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                <button type="button" id="btnGuardar" onClick="AplicarFiltros();" class="btn btn-primary">Aplicar Filtros</button>
              </div>
    	 </form>
    	</div>
  	</div>
   </div>
        

    
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/cdn_jquery.dataTables.min.js"></script>
    <script src="js/bootstrap.min.js"></script>    

     <script src="js/cdn_dataTables.buttons.min.js"></script>
     <script src="js/ajax_jszip.min.js"></script>
    <script src="js/ajax_pdfmake.min.js"></script>
    <script src="js/ajax_vfs_fonts.js"></script>
    <script src="js/cdn_buttons.html5.min.js"></script>
    <script src="js/cdn_buttons.print.min.js"></script>
    

  </body>
</html>

<script>
    $(document).ready(function() 
    {        	
       
      
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
            dom: 'Bfrtip',
            buttons: [
                'copy', 'excel', 'pdf', 'print'
            ]
        });
        
        

    });

    function AplicarFiltros()
    {
      
      if($('#fecha_desde').val() =="")
      {
        alert("Debe Ingresar Fecha desde");
        $('#fecha_desde').focus();  
        return;
      }


      if($('#fecha_hasta').val() =="")
      {
        alert("Debe Ingresar Fecha hasta");
        $('#fecha_hasta').focus();  
        return;
      }

      if($('#id_producto_tipo').val() == "0")      
        $('#tipo_descripcion').val("");      
      else      
        $('#tipo_descripcion').val($( "#id_producto_tipo option:selected" ).text());
      

      $('#FrmTipoFiltro').submit();
    }
    

</script>

<?php
  $db = null; //saco de memoria el objeto
?>