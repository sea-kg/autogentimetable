
<?php

include_once("config.php");   
include_once("classDB.php");
include_once("top.php");
print_top();
 
include("basepage.php");


echo "<form method='GET'>
   <input type='hidden' name='generate_tt' value='yes' /> 
   <input type='submit' value='generate time table' /> 
</form>
";


class FoundVariant
{
   var $db;

   function FoundVariant(&$db)
   {
      $this->db = $db;
   }

   function getGroups($filter, &$groups)
   {
     $result = $this->db->query( "select * from groups" );  
     $nCount = $this->db->count($result);
     for($i = 0; $i < $nCount; $i++)
         $groups[] = mysql_result( $result, $i, "id" );

     return $count;
   }

   function getSubjects($filter, &$subjects)
   {
      $idGroup = $filter['idGroup'];
      $result = $this->db->query( "select * from groups_subjects where id_groups = $idGroup order by id" );
      $nCount = $this->db->count($result);
      for($i = 0; $i < $nCount; $i++)
        $subjects[] = mysql_result( $result, $i, "id_subjects" );

      return $count;
   }

   function getTeachers($filter, &$teachers)
   {
      $idSubject = $filter['idSubject'];
      $result = $this->db->query( "select * from teachers_subjects where id_subjects = $idSubject order by id" );
      $nCount = $this->db->count($result);
      for($i = 0; $i < $nCount; $i++)
        $teachers[] = mysql_result( $result, $i, "id_teachers" );

      return $count;
   }

   function getRooms($filter, &$rooms)
   {
      $idSubject = $filter['idSubject'];
      $result = $this->db->query( "select * from rooms_subjects where id_subjects = $idSubject order by id" );
      $nCount = $this->db->count($result);
      for($i = 0; $i < $nCount; $i++)
        $rooms[] = mysql_result( $result, $i, "id_rooms" );

      return $count;
   }

   function getDaysTimes($filter, &$times)
   {
      $result = $this->db->query( "select * from days_times order by id_times, id_days" );
      $nCount = $this->db->count($result);
      for($i = 0; $i < $nCount; $i++)
        $times[] = mysql_result( $result, $i, "id" );

      return $count;
   }

   function rowsExists($name1, $id1, $name2, $id2)
   {
      $result = $this->db->query( "select * from timetable where $name1 = $id1 and $name2 = $id2" );
      return $this->db->count($result) >= 1;
   }

   function insertData($filter)
   {
      $idGroup = $filter['idGroup'];
      $idSubject = $filter['idSubject'];
      $idTeacher = $filter['idTeacher'];
      $idRoom = $filter['idRoom'];
      $idDayTime = $filter['idDayTime'];

      $result = $this->db->query( "INSERT INTO timetable(id_groups, id_subjects, id_teachers, id_rooms, id_days_times) 
VALUES($idGroup, $idSubject, $idTeacher, $idRoom, $idDayTime)" );

   }


   function getCurrentWeigthGroup($filter)
   {
      $idGroup = $filter['idGroup'];
      $idSubject = $filter['idSubject'];

      $query = "select SUM(days_times.weight) as sum_weight
                      from timetable 
                        inner join days_times on days_times.id = timetable.id_days_times
                      where id_subjects = $idSubject and id_groups = $idGroup";

      $res = 0;
      if( $this->db->count($result) == 1)
         $res = mysql_result( $result, 0, "sum_weight" );

      return $res;
   }
   
   function getMaxWeigthGroup($filter)
   {
      $idGroup = $filter['idGroup'];
      $idSubject = $filter['idSubject'];
      $result = $this->db->query( "select weight from groups_subjects where id_groups = $idGroup and id_subjects = $idSubject" );

      $res = 0;
      if( $this->db->count($result) == 1)
         $res = mysql_result( $result, 0, "weight" );

      return $res;
   }

   function getCurrentWeigthTeacher($filter)
   {
      $idGroup = $filter['idGroup'];
      $idTeacher = $filter['idTeacher'];

      $query = "select SUM(days_times.weight) as sum_weight
                      from timetable 
                        inner join days_times on days_times.id = timetable.id_days_times
                      where id_subjects = $idSubject and id_teachers = $idTeacher";

      $res = 0;
      if( $this->db->count($result) == 1)
         $res = mysql_result( $result, 0, "sum_weight" );

      return $res;
   }
   
   function getMaxWeigthTeacher($filter)
   {
      $idTeacher = $filter['idTeacher'];
      $idSubject = $filter['idSubject'];
      $result = $this->db->query( "select weight from teachers_subjects where id_teachers = $idTeacher and id_subjects = $idSubject" );

      $res = 0;
      if( $this->db->count($result) == 1)
         $res = mysql_result( $result, 0, "weight" );

      return $res;
   }
}


if(isset($_GET['generate_tt']))
{
   $gen_tt = $_GET['generate_tt'];
   if($gen_tt == "yes")
   {
      $db = new database();
      $db->connect($db_config);

      $db->query( "delete from timetable;" );

      $found = new FoundVariant($db);

      $groups;
      $teachers;
      $rooms;
      $subjects;
      $daystimes;
      $filter[] = '';

      $found->getGroups($filter, $groups);
      // echo "<hr><hr>".count($groups)."<hr><hr>";
      
      //echo "<pre>";
      // по всем группам
      for($nGroup = 0; $nGroup < count($groups); $nGroup++)
      {
         $filter['idGroup'] = $groups[$nGroup];
        // echo "\tGroupID=".$groups[$nGroup].";\r\n";

         unset($subjects);
         $found->getSubjects($filter, $subjects);
         // foreach() 
         for($nSubject = 0; $nSubject < count($subjects); $nSubject++)
         {
            $filter['idSubject'] = $subjects[$nSubject];
            //echo "\t\tSubjectID=".$subjects[$nSubject].";\r\n";
            
            $nCurrentWeightGroup = 0;
				$nMaxWeightGroup = 0;
            
            // вычисляем текущую нагрузку на группу по конкретному предмету
            $nCurrentWeightGroup = $found->getCurrentWeigthGroup($filter);
            //echo "\t\tCurrentWeightGroup = $nCurrentWeightGroup\r\n";

            // вычисляем требуемую нагрузку на группу
            $nMaxWeightGroup = $found->getMaxWeigthGroup($filter);
            //echo "\t\tMaxWeightGroup = $nMaxWeightGroup\r\n";

            if( $nMaxWeightGroup - $nCurrentWeightGroup <= 0)
				   continue; // переходим к следующему предмету

            unset($teachers);
            $found->getTeachers($filter, $teachers);
            
            for($nTeacher = 0; $nTeacher < count($teachers); $nTeacher++)
            {
               $filter['idTeacher'] = $teachers[$nTeacher];
               //echo "\t\t\tTeacherID=".$teachers[$nTeacher].";\r\n";
               
               $nCurrentWeightTeacher = 0;
				   $nMaxWeightTeacher = 0;
               
               // вычисляем текущую нагрузку на группу по конкретному предмету
               $nCurrentWeightTeacher = $found->getCurrentWeigthTeacher($filter);
               //echo "\t\t\tCurrentWeightTeacher = $nCurrentWeightTeacher\r\n";

               // вычисляем требуемую нагрузку на группу
               $nMaxWeightTeacher = $found->getMaxWeigthTeacher($filter);
               //echo "\t\t\tMaxWeightTeacher = $nMaxWeightTeacher\r\n";
               //$found->getSubjects($idGroup, $subjects);

               if($nMaxWeightTeacher - $nCurrentWeightTeacher <= 0 )
					   continue; // переходим к следующему учителю
   
               unset($rooms);
               $found->getRooms($filter, $rooms);

               for($nRoom = 0; $nRoom < count($rooms); $nRoom++)
               {
                  $filter['idRoom'] = $rooms[$nRoom];
                  // echo "\t\t\t\tRoomID=".$rooms[$nRoom].";\r\n";

					   if($nMaxWeightGroup - $nCurrentWeightGroup <= 0)
					      break; // если заполнили то прекращаем текущий цикл и поднимаемся на предыдущий уровень

                  unset($daystimes);
                  $found->getDaysTimes($filter, $daystimes);

                  for($nDayTime = 0; $nDayTime < count($daystimes); $nDayTime++)
                  {
                     $filter['idDayTime'] = $daystimes[$nDayTime];
                     //echo "\t\t\t\t\tDayTimeID=".$daystimes[$nDayTime].";\r\n";

                     $idDayTime = $filter['idDayTime'];
                     $idRoom    = $filter['idRoom'];
                     $idTeacher = $filter['idTeacher'];
                     $idGroup = $filter['idGroup'];

                     if(   
                           !$found->rowsExists('id_days_times', $idDayTime, 'id_rooms', $idRoom ) 
                           && !$found->rowsExists('id_days_times', $idDayTime, 'id_groups', $idGroup )
                           && !$found->rowsExists('id_days_times', $idDayTime, 'id_teachers', $idTeacher )

                     )
                     {

                        $found->insertData($filter);
						      $nCurrentWeightTeacher--; // минус один силе-ловкости
							   $nCurrentWeightGroup++; // плюс один к интелекту
                     }

                     if( $nMaxWeightGroup - $nCurrentWeightGroup <= 0)
         				   break; // переходим к следующему предмету                  
                  }
               }
            }
         } 
      }
     // echo "</pre>";
   };
   refreshTo("autogentimetable.php?result=$result");
};


if(isset($_GET['result']))
{
  echo "Result: ".($_GET['result']);
};
?>
