#!/usr/bin/sh

#find ./linux/ -name "Library" -exec /bin/rm -rf {} ";"
#find ./linux/ -name "Temp" -exec /bin/rm -rf {} ";"
find ./ -name "*.pidb" -exec /bin/rm {} ";"
find ./ -name "*.meta" -exec /bin/rm {} ";"
find ./ -name "*.userprefs" -exec /bin/rm {} ";"
find ./ -name "*.DS_Store"  -exec /bin/rm {} ";"
find ./ -name "*.unityproj" -exec /bin/rm {} ";"
echo "done! :)"
