FROM ubuntu:18.04
WORKDIR /app

# ICU magic
# see:
# https://stackoverflow.com/questions/61532592/installing-dotnet-core-in-ubuntu-end-up-having-dependency-comflicts
# http://site.icu-project.org/home
# https://stackoverflow.com/questions/61726014/icu-package-installation-linux

RUN  apt-get update \
  && apt-get install -y wget \
  && rm -rf /var/lib/apt/lists/*

RUN wget http://ftp.us.debian.org/debian/pool/main/i/icu/libicu57_57.1-6+deb9u4_amd64.deb
RUN dpkg -i libicu57_57.1-6+deb9u4_amd64.deb

COPY output/typeset-cli-linux .

ENTRYPOINT ["./typeset"]