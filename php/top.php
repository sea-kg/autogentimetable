<?

function print_top()
{
   echo "
Dictonary:
<table>
   <tr>
      <td> <a href='subjects.php'>Subjects</a> </td>
      <td> | </td>
      <td> <a href='groups.php'>Groups</a> </td>
      <td> | </td>
      <td> <a href='teachers.php'>Teachers</a> </td>
      <td> | </td>
      <td> <a href='rooms.php'>Rooms</a> </td>
      <td> | </td>
      <td> <a href='days.php'>Days</a> </td>
      <td> | </td>
      <td> <a href='times.php'>Times</a> </td>
      <td> | </td>
   </tr>

   <tr>
      <td></td>
      <td> | </td>
      <td> <a href='groups_subjects.php'>Groups - Subjects (Weight)</a> </td>
      <td> | </td>
      <td> <a href='teachers_subjects.php'>Teachers - Subjects (Weight)</a> </td>
      <td> | </td>
      <td> <a href='rooms_subjects.php'>Rooms - Subjects</a> </td>
      <td> | </td>
      <td> <a href='days_times.php'>Days - Times (Weight)</a> </td>
      <td> | </td>
   </tr>
   <tr>
      <td></td>
      <td> | </td>
      <td><a href='for_groups.php'>For Groups</a></td>
      <td> | </td>
      <td><a href='for_teachers.php'>For Teachers</a></td>
   </tr>
   <tr>
      
      <td><a href='autogentimetable.php'>Auto Gen Time Table</a></td>
      <td> | </td>
   </tr>
</table>
<hr>
";
};

?>
