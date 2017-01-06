nuget restore $(dirname "$0")/iTheatre.sln

xbuild $(dirname "$0")/iTheatre.sln /target:Build /p:Configuration=Release

sudo installer -pkg $(dirname "$0")/iTheatre/bin/Release/iTheatre-1.0.pkg -target /

open -a  $(dirname "$0")/iTheatre/bin/Release/iTheatre.app