#!/usr/bin/env bash
# Sair se der erro
set -o errexit

dotnet publish Loja3D/Loja3D.csproj -c Release -o out