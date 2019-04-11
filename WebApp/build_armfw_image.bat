docker build --force-rm -t armfw/iguardcore -f Dockerfile.armfw ../ 
REM echo y|docker system prune -a --filter "until=168h"
pause
