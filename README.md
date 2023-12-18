# Autofixture 101
Presentation for working with [autofixture](https://github.com/AutoFixture/AutoFixture)

I've used autofixture a little bit in one of my projects. It has a few up sides but also a few downsides. The downsides are horrendeous but the upsides makes maintaining tests a breeze.

The tradesoffs are largely worth it if you're strong enough - See [Lesson4](./Core.Test/Lesson4Tests.cs) if you want to skip to the end


# Key takeaways

## Believe in RNGeesus, mostly
RNG is heavily used for fixture data. However you should never assert on "preconfigured registered object patterns" in a test. This makes the tests more brittle when you do have to make some changes to a registered pattern.

This tool mildly explores fuzzing but it's not the same. It makes it easy to make fake data. Creating RNG data can sometimes fail but running the tests again "clears it" so it can lead you down a hole of bad, flakey tests.

## Order creation is important
Showcased in [Lesson3](./Core.Test/Lesson3Tests.cs), the order of which you create objects that have a dependency

## When you have to customize, you're doing it wrong
Autofixture's customizations leads you down a false sense of security. I would urge you to reconsider your approach every time you need to stub out yet another property on custom object creation. It's one of the anti-patterns that is not discussed often enough. 

You _should_ refactor your code, but will you? The simplier choice would be extend the existing pattern and hope it works. The lazy developer wins.

