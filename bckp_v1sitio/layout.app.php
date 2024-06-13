<?php
	session_start();
	require_once('data/class.database.php');

	class Layout
	{
		/*
			private static $menu = array(
			  array("Dashboard","index.php","glyphicon-cog",1,"index"),
			  array("Remitos","remitos.php","glyphicon-list-alt",0,"remitos"),
			  array("Reporte Inventario","reporte_inventario.php","glyphicon-list-alt",0,"reporte"),
			  array("Productos","productos.php","glyphicon-list-alt",0,"productos"),			  
			  array("Rubros","productos_tipo.php","glyphicon-list-alt",0,"productos_tipo"),
			  array("Clientes","responsables.php","glyphicon-list-alt",0,"responsables"),
			  array("Sucursales","sucursales.php","glyphicon-list-alt",0,"sucursales"),			  
			  array("Usuarios","usuarios.php","glyphicon-user",0,"usuarios")			  			  
		  );
		*/
			
		private static $menu = array(
			  array("Dashboard","index.php","glyphicon-cog",1,"index"),			  
			  array("Productos","productos.php","glyphicon-list-alt",0,"productos"),
			  array("Actualizar Precios","actualizacion.php","glyphicon-list-alt",0,"actualizacion"),
			  array("Rubros","productos_tipo.php","glyphicon-list-alt",0,"productos_tipo"),			  
			  array("Sucursales","sucursales.php","glyphicon-list-alt",0,"sucursales"),	
			  array("Proveedores","proveedores.php","glyphicon-list-alt",0,"proveedores"),		  
			  array("Usuarios","usuarios.php","glyphicon-user",0,"usuarios")			  			  
		  );
		  
		public static function VerificaSeguridad()
		{
			if(!$_SESSION['usuario'])
			{
				header("Location:login.php");
			}
		}
		
		public static function CreateMenuSuperior()
		{
			//seguridad
			if(!$_SESSION['usuario'])
			{
				echo("<script>location.href='login.php'</script>");
				die();
			}
			
			$_DES = 0;
			$_URL = 1;
			$_ICO = 2;
			$_CAN = 3;
			
			$CurrentPage = strtolower(basename($_SERVER['PHP_SELF']));
			
			for($row = 0; $row < count(self::$menu); $row++)
			{
				if($CurrentPage==self::$menu[$row][$_URL])
					echo "<li><a class='active' href='".self::$menu[$row][$_URL]."'>".self::$menu[$row][$_DES]."</a></li>";
				else
					echo "<li><a href='".self::$menu[$row][$_URL]."'>".self::$menu[$row][$_DES]."</a></li>";
			}	
		}
		
		public static function CreateMenuIzquierdo($current_section)
		{
			$_DES = 0;
			$_URL = 1;
			$_ICO = 2;
			$_CAN = 3;
			$_SEC = 4; //seccion donde está parado
			
			//$CurrentPage = strtolower(basename($_SERVER['PHP_SELF']));
			
			for($row = 0; $row < count(self::$menu); $row++)
			{
				if($current_section==self::$menu[$row][$_SEC])
					echo "<a href='".self::$menu[$row][$_URL]."' class='list-group-item active main-color-bg'>
							<span class='glyphicon ".self::$menu[$row][$_ICO]."' aria-hidden='true'></span> ".self::$menu[$row][$_DES]."
						  </a>";
				else
					echo "<a href='".self::$menu[$row][$_URL]."' class='list-group-item'>
							<span class='glyphicon ".self::$menu[$row][$_ICO]."' aria-hidden='true'></span> ".self::$menu[$row][$_DES]."</a>";
			}	
		}
		
		public static function CreateLogInfo()
		{
			echo "<li><a href='#'>Bienvenido, ".$_SESSION['usuario']."</a></li>";
			echo "<li><a href='login.php?exit=1'>Salir</a></li>";
		}
		
		public static function FooterInfo()
		{
			echo "<p>".VERSION_APP."</p>";
		}
		
		public static function StockInfo()
		{
			echo "<h4>Hueco del 12</h4>
                <div class='progress'>
                      <div class='progress-bar' role='progressbar' aria-valuenow='60' aria-valuemin='0' aria-valuemax='100' style='width: 60%;'>
                          60%
                      </div>
                </div>
            	<h4>Cemento</h4>
            	<div class='progress'>
                	<div class='progress-bar' role='progressbar' aria-valuenow='40' aria-valuemin='0' aria-valuemax='100' style='width: 40%;'>
                    	40%
            		</div>
          		</div>";
		}
		
		
		public static function cboRubros($default = "")
		{
			try
			{	
				$db = new Database();
				
				$sql ="select id_producto_rubro,descripcion from productos_rubros order by descripcion";
				$db->query($sql);
				$resultado = $db->resultset();
				
				if(strlen( $default)>0)
						echo "<option value='0' >$default</option>";
				foreach($resultado as $row) 
				{
					echo "<option value='".$row['id_producto_rubro']."' >".$row['descripcion']."</option>";
				}
				$db = null;
				
			}
			catch (Exception $e){
				echo $e->getMessage();
			}
			finally {
				$db = null;
			}
		}
		
		public static function cboFabricas()
		{
			try
			{	
				$db = new Database();
				
				$sql ="select id_fabrica,descripcion from fabrica where activo = 1";
				$db->query($sql);
				$resultado = $db->resultset();
				echo "<option value='0' > << SELECCIONE FABRICA >> </option>";
				foreach($resultado as $row) 
				{
					echo "<option value='".$row['id_fabrica']."' >".$row['descripcion']."</option>";
				}
				$db = null;
				
			}
			catch (Exception $e){
				echo $e->getMessage();
			}
			finally {
				$db = null;
			}
		}
		
		
		public static function cboCorralon()
		{
			try
			{	
				$db = new Database();
				
				$sql ="select id_corralon,descripcion from corralon where activo = 1";
				$db->query($sql);
				$resultado = $db->resultset();
				echo "<option value='0' > << SELECCIONE CORRALÓN >> </option>";
				foreach($resultado as $row) 
				{
					echo "<option value='".$row['id_corralon']."' >".$row['descripcion']."</option>";
				}
				$db = null;
				
			}
			catch (Exception $e){
				echo $e->getMessage();
			}
			finally {
				$db = null;
			}
		}
		
		
		public static function cboRemitosMetedoPago()
		{
			try
			{	
				$db = new Database();
				
				$sql ="select id_remitos_metedo_pago,descripcion from remitos_metedo_pagos order by id_remitos_metedo_pago";
				
				$db->query($sql);
				$resultado = $db->resultset();
				//echo "<option value='0' > << SELECCIONE METEDO PAGO >> </option>";
				foreach($resultado as $row) 
				{
					echo "<option value='".$row['id_remitos_metedo_pago']."' >".$row['descripcion']."</option>";
				}
				$db = null;
				
			}
			catch (Exception $e){
				echo $e->getMessage();
			}
			finally {
				$db = null;
			}
		}
		
	}
		

	//echo Layout::CreateMenuIzquierdo();

?>

				  
                  
                
                   
              
