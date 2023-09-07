<template>
  <!-- <vue-particles id="tsparticles" :particlesInit="particlesInit" :particlesLoaded="particlesLoaded"
    :options="particlesConfig"></vue-particles> -->
  <vue-particles id="tsparticles" :particlesInit="particlesInit" :options="options" />
</template>

<script setup name="animationBackground">
  //背景动画
  import { loadFull } from "tsparticles"
  import { loadBubblesPreset } from "tsparticles-preset-bubbles";
  import { loadFirePreset } from "tsparticles-preset-fire"
  import { loadFireworksPreset } from "tsparticles-preset-fireworks"
  import { loadBigCirclesPreset } from "tsparticles-preset-big-circles"
  import { loadConfettiPreset } from "tsparticles-preset-confetti"
  import { loadFountainPreset } from "tsparticles-preset-fountain"
  import { loadFireflyPreset } from "tsparticles-preset-firefly"
  import { loadLinksPreset } from "tsparticles-preset-links"
  import { loadSeaAnemonePreset } from "tsparticles-preset-sea-anemone"
  import { loadSnowPreset } from "tsparticles-preset-snow"
  import { loadStarsPreset } from "tsparticles-preset-stars"
  import { loadTrianglesPreset } from "tsparticles-preset-triangles"
  //import particlesConfig from "@/views/components/particles-bkg.json"
  //import particlesConfig from "@/views/components/particles-nasa.json"
  //import particlesConfig from "@/views/components/particles-star.json"
  // const particlesOptions = {
  //   preset: "fire",
  // }
  // const particlesOptions = {
  //   preset: "fireworks",
  // }
  // const particlesOptions = {
  //   preset: "bigCircles",
  // }
  // const particlesOptions = {
  //   preset: "triangles",
  // }

  const options = {
    preset: "fireworks",
  }
  const particlesInit = async engine => {
    await loadFireworksPreset(engine);
  }




  // const particlesLoaded = async container => {
  //   console.log("Particles container loaded", container);
  // }
</script>

<style scoped lang="scss">

</style>