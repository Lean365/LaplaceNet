<template>
  <div class="videoContainer">
    <video class="fullscreenVideo" ref="video" autoplay muted loop>
      <source :src="videoSrc" type="video/mp4">
    </video>
  </div>
</template>

<script setup>
  const videoSrc = 'src/assets/video/la.mp4'
</script>

<style scoped>
  .videoContainer {
    position: relative;
    right: 0px;
    bottom: 0px;
    left: 0px;
    min-width: 100%;
    min-height: 100%;
    width: 100%;
    height: 100%;

    overflow: hidden;
    z-index: -100;
  }

  .videoContainer:before {
    content: "";
    position: absolute;
    width: 100%;
    height: 100%;
    display: block;
    z-index: -1;
    top: 0;
    left: 0;
    background: rgba(25, 29, 34, .65);
  }
</style>