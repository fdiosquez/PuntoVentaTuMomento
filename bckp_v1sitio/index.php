<?php	
	$current_section = "index";
	require('layout.constantes.php');
	require('layout.app.php');
  require_once('data/class.database.php');

  $db = new Database(); //para todas la conexiones de esta pagina

  function GET_COLOR($indice) 
  {    
    $items = array("'#1e7145'","'#2b5797'","'#b91d47'","'#00aba9'","'#e8c3b9'");    
    return $items[$indice];
  }
  
  function random_color_part() {
    return str_pad( dechex( mt_rand( 0, 255 ) ), 2, '0', STR_PAD_LEFT);
  }

  function random_color() {
    return random_color_part() . random_color_part() . random_color_part();
  }

  function inicio_fin_semana($fecha)
  {

      $diaInicio="Monday";
      $diaFin="Saturday";

      $strFecha = strtotime($fecha);

      $fechaInicio = date('Y-m-d',strtotime('last '.$diaInicio,$strFecha));
      $fechaFin = date('Y-m-d',strtotime('next '.$diaFin,$strFecha));

      if(date("l",$strFecha)==$diaInicio){
          $fechaInicio= date("Y-m-d",$strFecha);
      }
      if(date("l",$strFecha)==$diaFin){
          $fechaFin= date("Y-m-d",$strFecha);
      }
      return Array("fechaInicio"=>$fechaInicio,"fechaFin"=>$fechaFin);
  }

?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><?php echo TITULO;?> | Panel</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <script src="js/chart.js"></script>
    

  </head>
  <body onLoad="">

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
            <h2><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Dashboard <small>/ Panel principal</small></h2>
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
          <div class="col-md-9">
            <!-- Website Overview -->
            <div class="panel panel-default">
              <div class="panel-heading main-color-bg">
                <h3 class="panel-title">Ventas de Hoy</h3>
              </div>
              <div class="panel-body">

              
             
                <div class="col-md-6">
                  <div class="well dash-box">                  	
                      <canvas id="myChartCajaSucursales" style="width:100%;max-width:600px"></canvas>
                  </div>
                </div>

                <?php

                  $fecha = date("Y-m-d"); 
                  
                  $GRAF_DESCRIPCIONES=[];
                  $GRAF_VALORES=[];
                  $GRAF_COLORES=[];

                  $sql = "SELECT 	a.ID_SUCURSAL,
                              sum(a.TOTAL_FINAL) AS TOTAL,
                                  b.descripcion 
                          FROM pedidos a inner join sucursales b 
                              on a.ID_SUCURSAL = b.id_sucursal  
                          WHERE a.fecha = '$fecha' and b.activo = 1
                          GROUP BY a.ID_SUCURSAL, b.descripcion";
                          
                 
                 
                  $db->query($sql);
                                                      
                  $resultado = $db->resultset();
                  $total_caja=0;
                  $i=0;
                  foreach($resultado as $row) 
                  {                   
                    $TOT = number_format($row['TOTAL']);
                    $NUM = str_replace(",",".",$TOT);                                      

                    $GRAF_DESCRIPCIONES[] = "'".$row['descripcion']."'";
                    $GRAF_VALORES[] = $NUM;
                    $GRAF_COLORES[] = GET_COLOR($i);

                    $TOTAL = $row['TOTAL'];
                    $descripcion = $row['descripcion'];
                    $total_caja += $TOTAL;
                    echo '<div class="col-md-3">
                            <div class="well dash-box">                  	
                                  <h4><b>Total Caja</b></h4>
                                  <h2><span class="glyphicon glyphicon-usd" aria-hidden="true" > '.number_format($TOTAL).'</span></h2>
                                  <h4>'.$descripcion.'</h4>                    
                            </div>
                          </div>';

                    $i++;
                  }

                  echo '<div class="col-md-3">
                        <div class="well dash-box">                  	
                              <h4><b>Caja Global</b></h4>
                              <h2><span class="glyphicon glyphicon-usd" aria-hidden="true" > '.number_format($total_caja).'</span></h2>
                              <h4>Todas las sucursales</h4>                    
                        </div>
                      </div>';


                  $sql ="SELECT a.ID_SUCURSAL, count(a.ID_PEDIDO) AS TOTAL, b.descripcion 
                          FROM pedidos a inner join sucursales b 
                            on a.ID_SUCURSAL = b.id_sucursal 
                          WHERE a.fecha = '$fecha' and b.activo = 1 
                          GROUP BY a.ID_SUCURSAL, 
                                b.descripcion";
                  $db->query($sql);                                                      
                  $resultado = $db->resultset();
                  foreach($resultado as $row) 
                  {
                    $TOTAL = $row['TOTAL'];
                    $descripcion = $row['descripcion'];                   

                    echo '<div class="col-md-3">
                            <div class="well dash-box">                  	
                                  <h4><b>Total Ventas</b></h4>
                                  <h2><span class="glyphicon glyphicon-shopping-cart" aria-hidden="true" > '.$TOTAL.'</span></h2>
                                  <h4>'.$descripcion.'</h4>                    
                            </div>
                          </div>';
                  }
                   
                 
                ?>
                
                

              </div>
            </div>      

            <div class="panel panel-default">
              <div class="panel-heading main-color-bg">
                <h3 class="panel-title">Ventas Semanal</h3>
              </div>
              <div class="panel-body">
                   <?php 
                        $info = inicio_fin_semana(date("Y-m-d"));
                        //$info = inicio_fin_semana("2024-02-05");
                        $data = GraficoSemanal($db,$info);                     
                        $i=0;
                        $count_sucu = 1;
                        
                      if(count($data)>0)
                      {
                        while ($i < count($data))
                        {
                            
                            $sucursal = $data[$i]["sucursal"];
                            while ($sucursal == $data[$i]["sucursal"])
                            {
                              $i++;
                              if($i == count($data))
                                  break;
                            }
                            echo '<div class="col-md-6">
                                    <div class="well dash-box">                  	
                                        <canvas id="myChart'.$count_sucu.'" style="width:100%;max-width:600px"></canvas>
                                    </div>
                                  </div>';
                            $count_sucu++;
                            if($i == count($data))
                              break;
                        }

                      }
                      else
                      {
                          echo '<div class="col-md-6">
                                <div class="well dash-box">                  	                                      
                                      <h4>Sin información Disponible</h4>                    
                                </div>
                              </div>';

                      }
                        
                   
                   ?>
              </div>
            </div>


            <div class="panel panel-default">
              <div class="panel-heading main-color-bg">
                <h3 class="panel-title">Ventas Mensuales por sucursal</h3>
              </div>
              <div class="panel-body">
                 
                             
                  <?php
                   $dataMen =  GraficoMensual($db);
                   

                   $count=0;
                   $i=0;
                   while ($i < count($dataMen))
                   {
                      
                       
                       $sucursal = $dataMen[$i]["sucursal"];
                       while ($sucursal == $dataMen[$i]["sucursal"])
                       {
                         $i++;
                         if($i == count($dataMen))
                             break;
                       }
                       echo '<div class="col-md-6">
                               <div class="well dash-box">                  	
                                   <canvas id="monthChart'.($count+1).'" style="width:100%;max-width:600px"></canvas>
                               </div>
                             </div>';
                       $count++;
                       if($i == count($dataMen))
                         break;
                   }
                  ?>
                                                    
              </div>
            </div>

            <div class="panel panel-default">
              <div class="panel-heading main-color-bg">
                <h3 class="panel-title">Top 50 productos mas vendidos todas las sucursales</h3>
              </div>
              <div class="panel-body">
                      <div class="col-md-6">
                            <table id="example" class="table table-striped table-hover " style="width:100%">
                              <thead>
                                  <tr>
                                      <th colspan="3">En cantidades</th>                                      
                                  </tr>
                                  <tr>
                                      <th>Cantidad</th>
                                      <th>Producto</th>                                                             
                                      <th>En Ventas</th>                                              
                                  </tr>
                              </thead>
                              <tbody>
                              <?php                              
            
                                  $sql ="SELECT count(pd.ID_PRODUCTO) as cantidad, 
                                                p.descripcion as producto, 
                                                count(pd.ID_PRODUCTO)*p.PRECIO as subtotal 
                                        FROM pedidos_detalle pd inner join productos p 
                                              on pd.ID_PRODUCTO = p.id_producto 
                                        inner join pedidos pe 
                                                on pe.id_pedido = pd.id_pedido 
                                        where YEAR(pe.fecha) = YEAR(CURDATE()) 
                                        group by p.descripcion 
                                        order by 1 desc LIMIT 50;";                            		
                                      
                                  $db->query($sql);
                                          
                                  $resultado = $db->resultset();

                                  foreach($resultado as $row) 
                                  {                                
                                      echo "<tr>";
                                      echo "<td>".$row['cantidad']."</td>";                                
                                      echo "<td>".$row['producto']."</td>";
                                      echo "<td class='text-right'> $".number_format($row['subtotal'],2,",",".")."</td>";
                                      echo "<tr>";                                    
                                  }
                                  
                                  
                              ?>                                               
                              </tbody>                    
                            </table>   
                      </div>
                      <div class="col-md-6">
                            <table id="example" class="table table-striped table-hover " style="width:100%">
                              <thead>
                                  <tr>
                                      <th colspan="3">En Ventas</th>                                      
                                  </tr>
                                  <tr>
                                      <th>Cantidad</th>
                                      <th>Producto</th>                                                             
                                      <th>En Ventas</th>                                              
                                  </tr>
                              </thead>
                              <tbody>
                              <?php                              
            
                                  $sql ="SELECT count(pd.ID_PRODUCTO) as cantidad, 
                                                p.descripcion as producto, 
                                                count(pd.ID_PRODUCTO)*p.PRECIO as subtotal 
                                        FROM pedidos_detalle pd inner join productos p 
                                              on pd.ID_PRODUCTO = p.id_producto 
                                        inner join pedidos pe 
                                                on pe.id_pedido = pd.id_pedido 
                                        where YEAR(pe.fecha) = YEAR(CURDATE()) 
                                        group by p.descripcion 
                                        order by 3 desc LIMIT 50;";                            		
                                      
                                  $db->query($sql);
                                          
                                  $resultado = $db->resultset();

                                  foreach($resultado as $row) 
                                  {                                
                                      echo "<tr>";
                                      echo "<td>".$row['cantidad']."</td>";                                
                                      echo "<td>".$row['producto']."</td>";
                                      echo "<td class='text-right'> $".number_format($row['subtotal'],2,",",".")."</td>";
                                      echo "<tr>";                                    
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

    <footer id="footer" class="hidden-md hidden-lg hidden-sm">
	   <?php Layout::FooterInfo();?>
    </footer>

    <!-- Modals -->


     <!-- NUEVO TIPO CAMBIO -->
    <div class="modal fade" id="addTipoCambio" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  		<div class="modal-dialog" role="document">
    	<div class="modal-content">
      		<form id="FrmTipoCambio">
			
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Tipo Cambio</h4>
              </div>
			  
              <div class="modal-body">
			  
			    <div class="form-group">
                  <label>Ultima Modificación</label>
                  <input type="text" name="fecha" class="form-control"  disabled>				
                </div>
				
                <div class="form-group">
                  <label>Tipo Cambio</label>
                  <input type="text" name="tipo_cambio" class="form-control" >
                </div>
				

              </div>
              <div class="modal-footer">
                <button type="button" id="btnCerrar" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                <button type="button" id="btnGuardar" onClick="GuardarTipoCambio();" class="btn btn-primary">Guardar Cambios</button>
              </div>
    	 </form>
    	</div>
  	</div>
   </div>



    <!-- Bootstrap core JavaScript
    ================================================== -->
    
    <script src="js/jquery-3.5.1.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <script>     

      //TORTA DIARIA
      var xValues = [<?php echo join(",",$GRAF_DESCRIPCIONES);?>];
        var yValues = [<?php echo join(",",$GRAF_VALORES);?>];
        var barColors = [<?php echo join(",",$GRAF_COLORES);?>];

        new Chart("myChartCajaSucursales", {
          type: "pie",
          data: {
            labels: xValues,
            datasets: [{
              backgroundColor: barColors,
              data: yValues
            }]
          },
          options: {
            title: {
              display: true,
              text: "TOTAL CAJA POR SUCURSAL"
            }
          }
        });

        //GRAFICO ESTADISTICO SEMANAL
        <?php   
            
            $i=0;
            $count_sucu = 1;
            while ($i < count($data))
            {
                
                $sucursal = $data[$i]["sucursal"];
                $dia = array();
                $valor = array();
                $color = array();
                while ($sucursal == $data[$i]["sucursal"])
                {
                  $dia[] = "'".$data[$i]["dia"]."'";
                  $valor[] = $data[$i]["valor"];
                  $color[] = "'".$data[$i]["color"]."'";

                  $i++;
                  if($i == count($data))
                      break;
                }
            

                echo 'var xValues'.$count_sucu.' = ['.join(",",$dia).'];
                      var yValues'.$count_sucu.' = ['.join(",",$valor).'];
                      var barColors'.$count_sucu.' = ['.join(",",$color).'];
                
                      new Chart("myChart'.$count_sucu.'", {
                        type: "bar",
                        data: {
                          labels: xValues'.$count_sucu.',
                          datasets: [{
                            backgroundColor: barColors'.$count_sucu.',
                            data: yValues'.$count_sucu.'
                          }]
                        },
                        options: {
                            legend: {display: false},
                            title: {
                              display: true,
                              text: "Sucursal '.$sucursal.'"
                            },
                            scales: {
                              yAxes: [{
                                  ticks: {
                                      beginAtZero: true,
                                      callback: function(value, index, values) {
                                          return "$" + value.toLocaleString(); 
                                      }
                                  }
                              }]
                            },
                            tooltips: {
                              callbacks: {
                                  label: function(tooltipItem, data) {
                                      var label = data.datasets[tooltipItem.datasetIndex].label || "";
                                      if (label) {
                                          label += ": ";
                                      }
                                      label += "$" + tooltipItem.yLabel.toLocaleString(); // Formatear el valor a moneda
                                      return label;
                                  }
                              }
                            }
                          
                          
                        }
                      }); '.PHP_EOL;
                $count_sucu++;
                if($i == count($data))
                  break;
            }
        
        ?> 

      //GRAFICO ESTADISTICO MENSUAL
      //
       <?php
        $i=0;
        $count_sucu = 1;
        while ($i < count($dataMen))
        {
            
            $sucursal = $dataMen[$i]["sucursal"];

            $mes = array();
            $valor = array();

            while ($sucursal == $dataMen[$i]["sucursal"])
            {
              $mes[] = "'".$dataMen[$i]["mes"]."'";
              $valor[] = $dataMen[$i]["valor"];              

              $i++;
              if($i == count($dataMen))
                  break;
            }

            echo '  const xMeses'.$count_sucu.' = ['.join(",",$mes).'];
                    const yValores'.$count_sucu.' = ['.join(",",$valor).'];
            
                    new Chart("monthChart'.$count_sucu.'", {
                      type: "line",
                      data: {
                        labels: xMeses'.$count_sucu.',
                        datasets: [{
                          fill: false,
                          lineTension: 0,
                          backgroundColor: "rgba(0,0,255,1.0)",
                          borderColor: "rgba(0,0,255,0.1)",
                          data: yValores'.$count_sucu.'
                        }]
                      },
                      options: {                      
                        legend: {display: false},
                        title: {
                                  display: true,
                                  text: "Sucursal '.$sucursal.'"
                                },
                        scales: {
                                  yAxes: [{
                                      ticks: {
                                          beginAtZero: true,
                                          callback: function(value, index, values) {
                                              return "$" + value.toLocaleString(); 
                                          }
                                      }
                                  }]
                              },
                        tooltips: {
                                  callbacks: {
                                      label: function(tooltipItem, data) {
                                          var label = data.datasets[tooltipItem.datasetIndex].label || "";
                                          if (label) {
                                              label += ": ";
                                          }
                                          label += "$" + tooltipItem.yLabel.toLocaleString(); // Formatear el valor a moneda
                                          return label;
                                      }
                                  }
                              }      
                      }
                    });';

            $count_sucu++;
            if($i == count($dataMen))
              break;

        }
       
       ?>     
        


      
    </script>
  </body>
</html>

<?php

  function GraficoSemanal($db,$info)
  {
    $ini= $info["fechaInicio"];
    $fin = $info["fechaFin"];
    
     // domingo = 1, lunes= 2,.... 
     $dia_semana = ["nada","Domingo","Lunes", "Martes", "Miercoles", "Jueves", "Viernes","Sabado"];
     $colores = ["nada","red", "green","blue","orange","brown","green","violet"];

      $sql = "SELECT 	a.FECHA,
                      dayofweek(a.FECHA) as day,
                      sum(a.TOTAL_FINAL) AS TOTAL,
                      b.id_sucursal, 
                      b.descripcion 
              
              FROM pedidos a inner join sucursales b 
                  on a.ID_SUCURSAL = b.id_sucursal  
              WHERE a.fecha BETWEEN '$ini' AND '$fin'
                    AND b.activo = 1 
              GROUP BY  a.id_sucursal,
                        a.FECHA, 
                        b.descripcion";
                      
      $db->query($sql);           
      $resultado = $db->resultset();
      $temp = array();
      foreach($resultado as $row) 
      {
        
        $temp[] = array( 
              'dia' =>$dia_semana[$row['day']],                                                 
              'color'=> $colores[$row['day']],
              'valor'=> $row['TOTAL'],
              'sucursal'=> $row['descripcion']
          );
      }
          
      return $temp;
    
  }


  function GraficoMensual($db)
  {
    
     // domingo = 1, lunes= 2,.... 
     $meses = ["nada","Ene","Feb","Mar", "Abr", "May", "Jun", "Jul","Ago","Sep","Oct","Nov","Dic"];     

      $sql = "SELECT 	 MONTH(a.FECHA) as mes,
                  sum(a.TOTAL_FINAL) AS TOTAL,
                    b.id_sucursal, 
              b.descripcion 

            FROM pedidos a inner join sucursales b 
              on a.ID_SUCURSAL = b.id_sucursal  
            WHERE YEAR(a.fecha) = YEAR(CURDATE())
                    AND b.activo = 1
            GROUP BY  a.id_sucursal,		  
                  b.descripcion,
                    MONTH(a.FECHA)";
                      
      $db->query($sql);           
      $resultado = $db->resultset();
      $dataRes = array();
      foreach($resultado as $row) 
      {
        $dataRes[] = array( 
              'mes' =>$meses[$row['mes']],                                                               
              'valor'=> $row['TOTAL'],
              'sucursal'=> $row['descripcion']
          );
      }
          
      return $dataRes;
    
  }

  $db = null;
?>