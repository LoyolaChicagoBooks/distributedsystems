#! /bin/bash

EXAMPLES=examples
mkdir -p $EXAMPLES
rm -rf $EXAMPLES/*

git clone https://github.com/LoyolaChicagoCode/hpjpc-source-java.git $EXAMPLES/hpjpc
git clone https://github.com/SoftwareSystemsLaboratory/systems-code-examples.git $EXAMPLES/systems-code-examples
git clone https://github.com/gkthiruvathukal/multicast-java.git $EXAMPLES/multicast-java
