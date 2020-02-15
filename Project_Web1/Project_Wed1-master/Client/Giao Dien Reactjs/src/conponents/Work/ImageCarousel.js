import React, { useState } from "react";
import { Carousel, Button } from "react-bootstrap";
const ImageCarousel = ({ images }) => {
  const CarouItem = images.map((item, i) => {
    return (
      <Carousel.Item key={i}>
        <img src={item.src} alt={item.alt} className="w-100 rounded" />
      </Carousel.Item>
    );
  });
  return <Carousel  className = "rounded">{CarouItem}</Carousel>;
};
export default ImageCarousel;
