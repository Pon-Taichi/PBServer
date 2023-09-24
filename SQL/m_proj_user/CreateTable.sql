DROP TABLE IF EXISTS pb.m_proj_user;

CREATE TABLE IF NOT EXISTS pb.m_proj_user (
    id SERIAL,
    proj_id int NOT NULL REFERENCES pb.m_project(id),
    user_id UUID NOT NULL REFERENCES pb.m_user(user_id),
    UNIQUE(proj_id, user_id)
);