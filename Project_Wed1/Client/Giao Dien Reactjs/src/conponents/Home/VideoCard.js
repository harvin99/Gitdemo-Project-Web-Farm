import React, { useState } from "react";
import { Button, CardDeck, Card, Row,Col } from "react-bootstrap";
const VideoCard = props => {
  const initVideoState = {
              src:"https://www.youtube.com/embed/ZwKhufmMxko",
              title:"0"
          
  };
  const [videoState, setCardVideoState] = useState(initVideoState);

  return (
        <Card className="text-center m-5 rounded">
            <Card.Header>
                <h4>Video</h4>
            </Card.Header>
            <Card.Body>
            <div className="embed-responsive embed-responsive-16by9">
                        <iframe  className="embed-responsive-item" title={videoState.title} src={videoState.src}
                            allowFullScreen ></iframe>
                    </div>
            </Card.Body>
        </Card>

  )
    
};
export default VideoCard;
