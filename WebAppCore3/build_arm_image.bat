docker build --force-rm -t arm/iguardcore3 -f Dockerfile.arm ../ 
docker save arm/iguardcore3 > core3-arm.tar
REM echo y|docker system prune -a --filter "until=168h"
pause
