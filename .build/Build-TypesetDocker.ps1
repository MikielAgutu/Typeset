$version = "0.0.1";

docker build -t mikielagutu/typeset:$version -f docker/Dockerfile .
docker build -t mikielagutu/typeset:latest -f docker/Dockerfile .

$result = docker run --rm mikielagutu/typeset:$version 2>&1

if ($result.ToString().contains("No such file or directory")) {
    throw "Bad configuration of Linux Typeset command lin - set LF line endings?"
}