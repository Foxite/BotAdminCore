#!/bin/sh

cd /botadmin
. config.sh
echo building $IMAGE_TAG
docker build -t $IMAGE_TAG .

if [ $PUSH = 'true' ]
then
  echo pushing
  docker push "$IMAGE_TAG"
else
  echo not pushing
fi
