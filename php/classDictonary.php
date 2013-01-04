
<?php
 
include("basepage.php");

//---------------------------------------------------------------------
	class pageDictonary
	{
		function pageDictonary($tablename)
		{
        $this->tablename = $tablename;
			return;
		}
      	
		function print_page()
		{
         include("config.php");

         if(isset($_GET['add']))
         {
            $get = $_GET['add'];
            $db = new database();
            $db->connect($db_config);

            $result = $db->query( "insert into ".$this->tablename."(name) values('".$get."');" );
            refreshTo($this->tablename.".php");
         };

         echo "<b>".$this->tablename."</b><br>"; 



         if(isset($_GET['edit']))
         {
            $get = $_GET['edit'];
            $db = new database();
            $db->connect($db_config);
            $result = $db->query( "select * from ".$this->tablename." where id = ".$get.";" );

            if( $db->count($result) == 1)
            {
		         $db_id_value = mysql_result( $result, 0, "id" );
               $db_name_value = mysql_result( $result, 0, "name" );	
            
   
                echo "<form method='GET'>
                     <input type='text' name='update' value='$db_name_value'/>
                     <input type='hidden' name='id' value='$get'/>
                     <input type='submit' value='Update'/>
                  </form>
               ";
                     
            }
            exit;
            //refreshTo($this->tablename.".php");
         };         

         if(isset($_GET['update']) && isset($_GET['id']))
         {
            $get = $_GET['update'];
            $id = $_GET['id'];
            $db = new database();
            $db->connect($db_config);
            $result = $db->query( "UPDATE ".$this->tablename." SET name = '$get' WHERE id = $id;" );

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

         $result = $db->query( "select * from ".$this->tablename." " );
	      $count = $db->count( $result );
	      echo "Found(".$count."):<br><br>";

         $color = "'#A4A4A4'";
         echo "<table cellpadding='5' cellspacing='0'>";

            echo "<tr bgcolor=$color>
                     <td>id</td>
                     <td>name</td>
                     <td></td>
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
            $db_name_value = mysql_result( $result, $i, "name" );	

            echo "<tr bgcolor=$color>
                     <td>$db_id_value</td>
                     <td>$db_name_value</td>
                     <td width='40px'/>
                     <td><a href='$this->tablename.php?edit=$db_id_value'>edit record</a></td>
                     <td><a href='$this->tablename.php?delete=$db_id_value'>delete record</a></td>
                  </tr>
";
	      };

         echo "</table>";


         echo "<form method='GET'>
            <input type='text' name='add' value=''/>
            <input type='submit' value='add'/>
         </form>
";
		}

		var $tablename;
	};
?>
