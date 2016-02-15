#!/usr/bin/sh

rm -rf ./Library
rm -rf ./Temp
find ./ -name "*.pidb" -exec /bin/rm {} ";"
find ./ -name "*.meta" -exec /bin/rm {} ";"
find ./ -name "*.userprefs" -exec /bin/rm {} ";"
find ./ -name "*.DS_Store"  -exec /bin/rm {} ";"
find ./ -name "*.unityproj" -exec /bin/rm {} ";"
echo "done! :)"
