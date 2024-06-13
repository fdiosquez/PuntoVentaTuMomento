<?php 
session_start();
require('fpdf185/fpdf.php');
require_once('data/class.database.php');

class PDF extends FPDF
{
	
	public $data = [];


	function Header()
	{
		
				
		$visible = 0;
		$alto_celda = 7;
		/*
		var_dump($this->data[0]["id_remito"]);
		die();
		*/
		
		$id_remito = $this->data[0][$_SESSION['ID_REMITO_FIELD']];
		$fecha = $this->data[0]["fecha"];
		$responsable = utf8_decode($this->data[0]["responsable"]);
		$destino = utf8_decode($this->data[0]["destino"]);
		$observaciones  = utf8_decode($this->data[0]["observaciones"]);

		// Logo
		$this->Image('img/logo_vivero.png',10,4,40);
		// Arial bold 15
		$this->SetFont('Arial','',16);
		// Movernos a la derecha
		$this->Cell(50);
		

		if($this->PageNo()=="1")
		{
			$TITULO = "REMITO ORIGINAL";
		}
		else
		{
			$TITULO = "REMITO DUPLICADO";
		}
		

		$this->Cell(80,10,$TITULO,0,0,'C');
		
		$this->Ln(5);
		
		//$this->SetTextColor(0,110,186);
		
		
		$this->SetLineWidth(.7);
		$this->Line(11, 25, 200, 25);
		
		$this->Ln();
		
		//RENGLON 1
		$this->SetFont('Arial','',10);
		$this->SetTextColor(0,0,0);
		$this->Cell(32,$alto_celda,'N'.iconv("UTF-8", "ISO-8859-1", "°").':',$visible,0,'L');
		$this->SetFont('Arial','B',10);
		$this->Cell(58,$alto_celda,str_pad($id_remito, 5, '0', STR_PAD_LEFT),$visible,0,'L');
		
		$this->SetFont('Arial','',10);
		$this->Cell(32,$alto_celda,'Responsable:',$visible,0,'L');
		$this->SetFont('Arial','B',10);
		$this->Cell(70,$alto_celda,$responsable,$visible,0,'L');		
		$this->Ln();
		
		//RENGLON 2
		$this->SetFont('Arial','',10);
		$this->Cell(32,$alto_celda,'Fecha:',$visible,0,'L');
		$this->SetFont('Arial','B',10);
		$this->Cell(58,$alto_celda,$fecha,$visible,0,'L');
				
		$this->SetFont('Arial','',10);
		$this->Cell(32,$alto_celda,'Destino:',$visible,0,'L');
		$this->SetFont('Arial','B',10);
		$this->Cell(70,$alto_celda,$destino,$visible,0,'L');		
		$this->Ln();
		
		
		$this->SetFont('Arial','',10);
		$this->Cell(32,$alto_celda,'Observaciones:',$visible,0,'L');
		$this->SetFont('Arial','B',10);
		$this->Cell(160,$alto_celda,$observaciones,$visible,0,'L');		
		$this->Ln();

		$this->SetLineWidth(.7);
		$this->Line(11, 46, 200, 46);

		// Guardar ordenada
		$this->y0 = $this->GetY();

		$db = null;
	}
	
	function Footer()
	{		
		$this->SetY(-15);
		$this->SetFont('Arial','I',8);
		$this->SetTextColor(128);
		$this->Cell(0,10,'P'.iconv("UTF-8", "ISO-8859-1", "á").'gina '.$this->PageNo(),0,0,'C');
	}


	// Tabla coloreada
	function addDetalle()
	{
		$this->Ln();
		// Colors, line width and bold font
		$this->SetFillColor(0,0,0);
		$this->SetTextColor(255);
		$this->SetDrawColor(0,0,0); //borde de la tabla
		$this->SetLineWidth(.3);
		$this->SetFont('','B');

		$this->Cell(20,7,"CANTIDAD",1,0,'C',true);
		$this->Cell(40,7,"TIPO",1,0,'C',true);
		$this->Cell(130,7,"DESCRIPCION",1,0,'C',true);	
		
		$this->Ln();

		
		$this->SetFillColor(224,235,255);
		$this->SetTextColor(0);
		$this->SetFont('');

		$fill = false;
		foreach($this->data as $row) 
		{
					
			$this->Cell(20,6,$row['cantidad'],'LR',0,'R',$fill);
			$this->Cell(40,6,$row['tipo'],'LR',0,'L',$fill);
			$this->Cell(130,6,$row['producto'],'LR',0,'L',$fill);		
			$this->Ln();
			$fill = !$fill;
		}
		
		$this->Cell(190,0,'','T');

		$db = null;
		
	}



}

	$pdf = new PDF();
	$db  = new Database();

	$id_remito = $_REQUEST["id"];
	

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
			WHERE r.id_remito = $id_remito";

	$db->query($sql);
			
	$resultado = $db->resultset();

	$pdf->data = $resultado;
	$pdf->AddPage();
	$pdf->addDetalle();
	$pdf->AddPage();
	$pdf->addDetalle();
	$pdf->Output();
?>

