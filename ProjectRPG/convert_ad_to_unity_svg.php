<?php
//git bash: php <script_name>
function SvgMoveDefs(string $sSvg){
	//Regex arguments: i -> small and big chars | s -> meta-char (.) also matches new line
	if(preg_match("#<defs>.*?</defs>#is", $sSvg, $aMatches, PREG_OFFSET_CAPTURE)){
		$iLength = strlen($aMatches[0][0]);	// arr in arr: first captured string
		$iOffset = $aMatches[0][1];			// arr in arr: offset of first string
		
		$sSvg = substr($sSvg, 0, $iOffset) . substr($sSvg, $iOffset + $iLength);
		
		if(preg_match("#<svg.*?>#is", $sSvg, $aPasteMatches, PREG_OFFSET_CAPTURE)){
			$iPasteOffset = $aPasteMatches[0][1] + strlen($aPasteMatches[0][0]);
			
			return substr($sSvg, 0, $iPasteOffset) . $aMatches[0][0] . substr($sSvg, $iPasteOffset);
		}
		else{
			echo "Error: <svg.*?> not found!\n";
		}
	}
	else{
		echo "Error: <defs>.*?</defs> not found!\n";
	}
	
	return null;
}

function SaveNewSvg(string $sNewSvg, string $sOutputPath){
	if(!file_exists($sNewSvg)){
		echo "Error: File \"$sNewSvg\" doesn't exist!";
		return false;
	}
	
	$sOutputPath = realpath($sOutputPath);
	if(!is_dir($sOutputPath)){
		echo "Error: Dir \"$sOutputPath\" doesn't exist!";
		return false;
	}
	
	$sSvg = SvgMoveDefs(file_get_contents($sNewSvg));
	if($sSvg === null) {
		echo "\tin $sNewSvg\n";
		return false;
	}
	
	$aPathInfo = pathinfo($sNewSvg);
	file_put_contents($sOutputPath."/".$aPathInfo["basename"], $sSvg);
	
	return true;
}




$sDirPath = getcwd();

$sPath = realpath($sDirPath);
if($sPath === false) {
    fwrite(STDERR, "path '$sDirPath' doesn´t exist\n");
    exit(1);
}
$sNewDirPath = $sDirPath . "/newSvg";
if(!is_dir($sNewDirPath)) {
	mkdir($sNewDirPath);
}



foreach(array_diff(scandir($sPath), [".", ".."]) as $sFile) {
    $sFilePath = $sPath."/".$sFile;
	
	if(is_file($sFilePath)){
		$aPathInfo = pathinfo($sFilePath);
		switch(strtolower($aPathInfo["extension"])) {
			case "svg":
				SaveNewSvg($sFilePath, $sNewDirPath);
		}
	}
}