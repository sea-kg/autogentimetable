<?php 
//---------------------------------------------------------------------
	class database
	{
		function connect($db_config)
		{
			//include_once($config);
			$this->db = mysql_connect( 
				$db_config['db_host'], 
				$db_config['db_username'], 
				$db_config['db_userpass']) or die("don't connect to db");

			mysql_query("SET NAMES 'utf8_general_ci'", $this->db);

			// mysql_set_charset ( 'utf8_general_ci', $this->db );

			mysql_select_db( $db_config['db_namedb'], $this->db);
			return true;
		}
		
		function query( $query )
		{
			$result = mysql_query( $query, $this->db );
			return $result;
		}
		
		function count( &$mysql_result )
		{
			$count = mysql_num_rows( $mysql_result );
			return $count;
		}

		var $db;	
	};
	//---------------------------------------------------------------------
	function strtodb( $str )
	{
		return mysql_real_escape_string(htmlspecialchars($str));
	};
?>
