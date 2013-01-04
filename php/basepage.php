<?
   	function refreshTo($new_page)
	{
		//header ("Location: $new_page");
		
		echo "
		<html>
<head>
<script type='text/javascript'>
<!--
function delayer(){
    window.location = '$new_page'
}
//-->
</script>
</head>
<body onLoad=\"setTimeout('delayer()', 0)\">
<h2>Prepare to be redirected!</h2>
<p>This page is a time delay redirect, please update your bookmarks to our new 
location!</p>

</body>
</html>
";
		exit;
	}


?>
