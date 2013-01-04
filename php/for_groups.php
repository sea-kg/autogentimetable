
<?php

include_once("config.php");   
include_once("classDB.php");
include_once("top.php");
print_top();
 
include("basepage.php");


$db = new database();
$db->connect($db_config);


$result1 = $db->query( "select * from days where days.id in (select id_days from days_times) order by days.id;" );
$count1 = $db->count($result1);

$result2 = $db->query( "select * from times where times.id in (select id_times from days_times) order by times.id;" );
$count2 = $db->count($result2);

$result3 = $db->query( "select * from groups where groups.id in (select id_groups from timetable) order by groups.id;" );  
$count3 = $db->count($result3);

function getColor($n)
{
  if($n % 2 == 0)
    return "'#A4A4A4'";
  return "'#D8D8D8'";
};


function getData(&$db, $nGroup, $nDay, $nTime)
{
   $query = "select 
      teachers.name as teacher_name,  
      rooms.name as room_name,
      subjects.name as subject_name
   from timetable 
      inner join teachers on teachers.id = timetable.id_teachers
      inner join rooms on rooms.id = timetable.id_rooms
      inner join subjects on subjects.id = timetable.id_subjects
      inner join days_times on days_times.id = timetable.id_days_times
   where timetable.id_groups = $nGroup and days_times.id_days=$nDay and days_times.id_times=$nTime";

   //echo "<hr>".$query."<hr>";
   $result4 = $db->query($query);
   
   if( $db->count($result4) == 1)
   {
      $answer = "<font size=2 >".mysql_result( $result4, 0, "subject_name" )."<br>".
        mysql_result( $result4, 0, "room_name" )."<br>".
        mysql_result( $result4, 0, "teacher_name" )."</font>"
     ;
     return $answer; 
   }

   return "-"; //$db->count($result4); 
   //return ".";
};

echo "<table cellpadding='5' cellspacing='0'>";

for($nGroup = 0; $nGroup < $count3; $nGroup++ )
{
   $idGroup = mysql_result( $result3, $nGroup, "id" );


   echo "<tr><td valign='middle' align='center' colspan=".($count1+1)."><td></tr>";

   echo "<tr><td valign='middle' align='center' bgcolor='#04B486' colspan=".($count1+1)."><b>".mysql_result( $result3, $nGroup, "name" )."</b><td></tr>";
   // echo titles
   echo "<tr>";
   echo "<td valign='middle' bgcolor=".getColor($nDay-1).">Time\Day</td>";
   for($nDay = 0; $nDay < $count1; $nDay++)
   {
      echo "<td valign='middle' align='center' bgcolor=".getColor($nDay).">".mysql_result( $result1, $nDay, "name" )."</td>";
   }
   echo "</tr>";

   for($nTime = 0; $nTime < $count2; $nTime++)
   {
      $idTime = mysql_result( $result2, $nTime, "id" );

      echo "<tr>";
      echo "<td valign='middle' align='center' bgcolor=".getColor($nTime).">".mysql_result( $result2, $nTime, "name" )."</td>"; 
      for($nDay = 0; $nDay < $count1; $nDay++)
      {
        $idDay = mysql_result( $result1, $nDay, "id" );
        echo "<td valign='middle' align='center' bgcolor=".getColor($nTime + $nDay + 1).">".getData($db, $idGroup, $idDay, $idTime)."</td>";
      }
      echo "</tr>";
   };
}
   echo "</table>";
?>
