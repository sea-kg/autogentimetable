
<?php
 
include("basepage.php");

//---------------------------------------------------------------------
	class pageBunch
	{
		function pageBunch($tablename1, $tablename2, $weight)
		{
         $this->tablename1 = $tablename1;
         $this->tablename2 = $tablename2;
         $this->tablename = $tablename1."_".$tablename2;
         $this->weight = $weight;
			return;
		}

		function print_page()
		{
         include("config.php");

         echo "<b>".$this->tablename1." - ".$this->tablename2."</b><br>"; 


         if(isset($_GET['add_id1']) && isset($_GET['add_id2']) )
         {
            $add1 = $_GET['add_id1'];
            $add2 = $_GET['add_id2'];
            $weight = "";
            $column = ""; 
            if(isset($_GET['weight']))
            {
               $weight = ",".$_GET['weight'];
               $column = ", weight";
            }
            
            $db = new database();
            $db->connect($db_config);
            
            $t1 = $this->tablename1;
            $t2 = $this->tablename2;

            $result = $db->query( "insert into ".$this->tablename."(id_".$t1.", id_".$t2." $column) 
                                    values(".$add1.",".$add2." $weight);" );

            refreshTo($this->tablename.".php");
         };

         if(isset($_GET['delete']))
         {
            $get = $_GET['delete'];
            $db = new database();
            $db->connect($db_config);
            $result = $db->query( "DELETE FROM ".$this->tablename." WHERE id = $get;" );

            refreshTo($this->tablename.".php");
         }; 

		   $db = new database();
         $db->connect($db_config);

         $t = $this->tablename;
         $t1 = $this->tablename1;
         $t2 = $this->tablename2;
   
         $column = "";
         $column_name = "";
         if($this->weight == "yes")
         {
            $column = ", ".$t.".weight";
            $column_name = "<td>weight</td>";
         };

         $query = "
SELECT ".$t.".id, ".$t1.".name AS ".$t1."_name, ".$t2.".name AS ".$t2."_name $column
FROM ".$t."
INNER JOIN ".$t1." ON ".$t.".id_".$t1." = ".$t1.".id
INNER JOIN ".$t2." ON ".$t.".id_".$t2." = ".$t2.".id
ORDER BY ".$t1.".id,".$t2.".id
";

         $result = $db->query( $query );
	      $count = $db->count( $result );
	      echo "Found(".$count."):<br><br>";

         $color = "'#A4A4A4'";
         echo "<table cellpadding='5' cellspacing='0'>";

            echo "<tr bgcolor=$color>
                     <td>id</td>
                     <td>name1</td>
                     <td>name2</td>
                     $column_name
                     <td></td>
                     <td></td>
                  </tr>
         ";

         //$color = 
	      for($i = 0; $i < $count; $i++)
	      {
            if($i % 2 == 0) 
               $color = "'#D8D8D8'";
            else
               $color = "'#A4A4A4'";

		      $db_id_value = mysql_result( $result, $i, "id" );
            $db_name1_value = mysql_result( $result, $i, $t1."_name" );	
            $db_name2_value = mysql_result( $result, $i, $t2."_name" );	
            
            $column_name2 = "";
            if($this->weight == "yes")
            {
               $db_weight_value = mysql_result( $result, $i, "weight" );	
               $column_name2 = "<td>$db_weight_value</td>";
            }

            echo "<tr bgcolor=$color>
                     <td>$db_id_value</td>
                     <td>$db_name1_value</td>
                     <td>$db_name2_value</td>
                     $column_name2
                     <td width='40px'/>
                     <td><a href='$this->tablename.php?delete=$db_id_value'>delete record</a></td>
                  </tr>
";
	      };

         echo "</table>";


         echo"
         <form method='GET'>
            <select name='add_id1'>";

            $this->get_list_of_options($t1);

         echo "</select>
            <select name='add_id2'>";
            $this->get_list_of_options($t2);

         echo "</select>";
            

         if($this->weight == "yes")
            echo " weight: <input type='text' name='weight' value=''/>";         
  
         echo "
            <input type='submit' value='add'/>
         </form>
         ";
		}

      function get_list_of_options($tablename)
      {
         include("config.php");
		   $db = new database();
         $db->connect($db_config);

         $t = $this->tablename;
         $t1 = $this->tablename1;
         $t2 = $this->tablename2;

         $result = $db->query( "select * from $tablename" );
	      $count = $db->count( $result );

         
         echo "\r\n\t<option disabled>$tablename</option>";

	      for($i = 0; $i < $count; $i++)
	      {
		      $db_id_value = mysql_result( $result, $i, "id" );
            $db_name_value = mysql_result( $result, $i, "name" );  
            echo "\r\n\t<option value='$db_id_value'>$db_name_value</option>";
	      };
      }

		var $tablename1;
		var $tablename2;
      var $tablename;
	};
?>
