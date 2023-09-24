DROP TABLE IF EXISTS pb.m_user;

CREATE TABLE IF NOT EXISTS pb.m_user (
    user_id UUID PRIMARY KEY,
    user_name VARCHAR(32) NOT NULL
);