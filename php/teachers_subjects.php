<?
   include_once("config.php");   
   include_once("classDB.php");
   include_once("classBunch.php");
   include_once("top.php");
   print_top();
   
   $page = new pageBunch("teachers", "subjects", "yes");
   $page->print_page();
?>
