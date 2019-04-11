docker build --force-rm -t arm/iguardcore -f Dockerfile.arm ../ 
REM echo y|docker system prune -a --filter "until=168h"
pause
