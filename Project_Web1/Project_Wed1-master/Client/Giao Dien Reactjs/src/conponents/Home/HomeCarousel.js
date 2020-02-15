import React, { useState } from "react";
import { Navbar, Nav, Carousel, Button } from "react-bootstrap";
const HomeCarousel = props => {
  const initCarouselItem = {
    activeIndex: 0,
    list: [
      {
        alt: "Banner 1",
        src: "./../images/LandingPage/Targo_Images/banner1.jpg"
      },
      {
        alt: "Banner 2",
        src: "./../images/LandingPage/Targo_Images/banner2.jpg"
      },
      {
        alt: "Banner 3",
        src: "./../images/LandingPage/Targo_Images/banner3.jpg"
      }
    ]
  };
  const [CarouselItem, setCarouselItem] = useState(initCarouselItem);
  const CarouItem = CarouselItem.list.map((item, i) => {
    return (
      <Carousel.Item key={i}>
        <img src={item.src} alt={item.alt} className="w-100 rounded" />
        <Carousel.Caption>
          <Button variant="primary">Book a Room</Button>
        </Carousel.Caption>
      </Carousel.Item>
    );
  });
  return <Carousel className="rounded mt-4">{CarouItem}</Carousel>;
};
export default HomeCarousel;
