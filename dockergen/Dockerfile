FROM nginxproxy/docker-gen

RUN apk add docker-cli

COPY Dockerfile.tmpl /botadmin/Dockerfile.tmpl
COPY build.sh /botadmin/build.sh
RUN echo '$1 > /proc/1/fd/1' > /botadmin/diag.sh
RUN chmod +x /botadmin/build.sh /botadmin/diag.sh
