# Autofixture 101
Presentation for working with [autofixture](https://github.com/AutoFixture/AutoFixture)

This framework helps you speed up testing by injecting things you care about and reduces setup cost (under most circumstances). 

I've used autofixture a little bit in one of my projects. Like with all organic projects, your code will definitely not be the same as the ones provided in a vaccuume in the tutorials. It'll have weird nooks and crannies that just don't work well with this framework. The following lessons will demonstrate how to bolt this on and address up to 80% of your general use case.

Presentation Link

![](./Docs/qrcode_github.com.png)

## TLDR for the juicy bits
See [Lesson4](./Core.Test/Lesson4Tests.cs)

# Key takeaways

## Believe in RNGeesus, mostly
RNG is heavily used for fixture data. However you should never assert on "preconfigured registered object patterns" in a test. This makes the tests more brittle when you do have to make some changes to a registered pattern.

This tool mildly explores fuzzing but it's not the same. Unit tests in theory shouldn't be RNG but if it does break because of some RNG data, it means your setup condition is dirty and contaminated and needs to be revisited. 

## Order creation is important
Showcased in [Lesson3](./Core.Test/Lesson3Tests.cs), the order of which you create objects is important. Especially when it comes to dependent services. 

## When you have to customize, you're doing it wrong
Autofixture's customizations leads you down a false sense of security. I would urge you to reconsider your approach every time you need to stub out yet another property on custom object creation. It's one of the anti-patterns that this framework introduces. 
