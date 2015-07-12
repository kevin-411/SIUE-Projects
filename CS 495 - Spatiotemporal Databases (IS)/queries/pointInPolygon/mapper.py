#!/usr/bin/env python
'''
Created on November 16, 2013

@author: Brian
'''
import sys
import raincloudregion

mcrc = raincloudregion.translateMovingRegion(sys.stdin)

word = mcrc.color

word = word.strip()

print '%s\t%s' % (word, 1)
