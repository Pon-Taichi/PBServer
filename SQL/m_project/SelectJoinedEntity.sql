SELECT p.proj_name, p.proj_description, p.proj_owner, u.user_name, pu.user_id, pu.user_name
FROM pb.m_project AS p

INNER JOIN pb.m_user as u
ON p.proj_owner = u.user_id

LEFT OUTER JOIN (
    SELECT pu1.proj_id, pu1.user_id, u1.user_name
    FROM pb.m_proj_user AS pu1
    INNER JOIN pb.m_user AS u1
    ON pu1.user_id = u1.user_id
) AS pu
ON p.id = pu.proj_id