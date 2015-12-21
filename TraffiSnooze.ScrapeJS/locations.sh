
rm -f output.txt
alpha="abcdefghijklmnopqrstuvwxyz"
for (( i=0; i<${#alpha}; i++ )); do
  tzeChar="${alpha:$i:1}"
  echo $tzeChar;
  curl --silent "http://touringmobilis.myroute.be/Locations.asmx/GetCompletionList?prefixText=$tzeChar&count=1000" >> temp.txt
done

cat temp.txt | grep "<string>" | sed "s/<string>\(.*\)<\/string>/\1/" > output.txt

rm -f temp.txt