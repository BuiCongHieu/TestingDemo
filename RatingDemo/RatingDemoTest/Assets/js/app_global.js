const mapEmoji = {
    1: "../../Assets/images/images/emoji/crying.png",
    2: "../../Assets/images/images/emoji/sad.png",
    3: "../../Assets/images/images/emoji/happy.png",
    4: "../../Assets/images/images/emoji/smile.png",
    5: "../../Assets/images/images/emoji/in-love.png",
};

const mapMessafe = {
    // ve sinh messages
    1: {
        1: "Rất không sạch sẽ",
        2: "Không sạch sẽ",
        3: "Chấp nhận được",
        4: "Sạch sẽ",
        5: "Rất sạch sẽ",
    },
    2: {
        1: "Rất không thân thiện",
        2: "Không thân thiện",
        3: "Chấp nhận được",
        4: "Thân thiện",
        5: "Rất thân thiện",
    },
    3: {},
};

function getEmoji(stars) {
    return mapEmoji[stars];
}

function getMessage(serviceId, stars) {
    return mapMessafe[serviceId][stars];
}