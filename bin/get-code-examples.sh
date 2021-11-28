#! /bin/bash

EXAMPLES=examples
mkdir -p $EXAMPLES
rm -rf $EXAMPLES/*

git clone git@github.com:LoyolaChicagoCode/hpjpc-source-java.git $EXAMPLES/hpjpc
git clone git@github.com:SoftwareSystemsLaboratory/systems-code-examples.git $EXAMPLES/systems-code-samples
git clone git@github.com:gkthiruvathukal/multicast-java.git $EXAMPLES/multicast-java
