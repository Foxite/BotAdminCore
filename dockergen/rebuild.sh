#!/bin/sh

cd $(dirname $0)
pwd > /botsome/pwd
echo $IMAGE > /botsome/image
exit

docker build -t $IMAGE .
docker push $IMAGE
