docker build --force-rm -t arm/iguardcore -f Dockerfile.arm ../ 
docker save arm/iguardcore > core-arm.tar
REM echo y|docker system prune -a --filter "until=168h"
pause
